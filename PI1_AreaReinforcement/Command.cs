using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.IFC;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PI1_AreaReinforcement
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    // Start command class.
    public class Command : IExternalCommand
    {
        /// <summary>
        /// Overload this method to implement and external command within Revit.
        /// </summary>
        /// <param name="commandData">An ExternalCommandData object which contains reference to Application and View
        /// needed by external command.</param>
        /// <param name="message">Error message can be returned by external command. This will be displayed only if the command status
        /// was "Failed".  There is a limit of 1023 characters for this message; strings longer than this will be truncated.</param>
        /// <param name="elements">Element set indicating problem elements to display in the failure dialog.  This will be used
        /// only if the command status was "Failed".</param>
        /// <returns>
        /// The result indicates if the execution fails, succeeds, or was canceled by user. If it does not
        /// succeed, Revit will undo any changes made by the external command.
        /// </returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            IList<Reference> references = uidoc.Selection.PickObjects(ObjectType.Element, new SelectionFilter(), "Выберите объекты для армирования по площади");

            CreateReinforcementData userInfo = null;
            using (var window = new AreaReinforcementForm(uidoc))
            {
                window.ShowDialog();
                userInfo = window.GetInformation();
            }            

            ElementId areaReinforcementTypeId = new FilteredElementCollector(doc)
                .OfClass(typeof(AreaReinforcementType))
                .ToList()
                .FirstOrDefault(area => area.Name.Equals("основная")).Id;
            ElementId rebarBarTypeId = userInfo.RebarBarTypeId;
            ElementId hookTypeId = ElementId.InvalidElementId;
            double SpacingValue = userInfo.SpacingValue;

            using (Transaction t = new Transaction(doc, "Армирование по площади"))
            {
                t.Start();

                foreach (var reference in references)
                {
                    Element element = doc.GetElement(reference.ElementId);                    
                    CreateReinforcementCommand areaReinforcement = new CreateReinforcementCommand(doc, element, SpacingValue, areaReinforcementTypeId, rebarBarTypeId, hookTypeId);
                }

                t.Commit();
            }

            return Result.Succeeded;
        }

        /// <summary>
        /// Gets the path of the current command.
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            return typeof(Command).Namespace + "." + nameof(Command);
        }
    }
}
