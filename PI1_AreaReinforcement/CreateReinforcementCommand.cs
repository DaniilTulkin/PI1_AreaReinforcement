using Autodesk.Revit.DB;
using Autodesk.Revit.DB.IFC;
using Autodesk.Revit.DB.Structure;
using System.Collections.Generic;
using System.Linq;

namespace PI1_AreaReinforcement
{
    public class CreateReinforcementCommand
    {
        public CreateReinforcementCommand(Document doc, Element element, double SpacingValue, ElementId areaReinforcementTypeId, ElementId rebarBarTypeId, ElementId hookTypeId)
        {            
            IList<Reference> sideFaces = new List<Reference>();
            XYZ xyz = null;
            switch (element.Category.Id.IntegerValue)
            {
                case (int)BuiltInCategory.OST_Walls:
                    sideFaces = HostObjectUtils.GetSideFaces((element as HostObject), ShellLayerType.Exterior);
                    xyz = new XYZ(0, 0, 1);
                    break;
                case (int)BuiltInCategory.OST_Floors:
                    sideFaces = HostObjectUtils.GetTopFaces((element as HostObject));
                    xyz = new XYZ(0, 1, 0);
                    break;
                case (int)BuiltInCategory.OST_StructuralFoundation:
                    sideFaces = HostObjectUtils.GetTopFaces((element as HostObject));
                    xyz = new XYZ(0, 1, 0);
                    break;
            }

            Element firstSideFace = doc.GetElement(sideFaces[0]);
            Face face = firstSideFace.GetGeometryObjectFromReference(sideFaces[0]) as Face;
            IList<CurveLoop> curveLoops = face.GetEdgesAsCurveLoops();
            IList<IList<CurveLoop>> curveLoopLoop = ExporterIFCUtils.SortCurveLoops(curveLoops);
            CurveLoop outerCurveLoop = curveLoopLoop.First().First();

            IList<Curve> curves = new List<Curve>();
            foreach (Curve curve in outerCurveLoop)
            {
                curves.Add(curve);
            }

            double diameter = doc.GetElement(rebarBarTypeId).get_Parameter(BuiltInParameter.REBAR_BAR_DIAMETER).AsDouble();

            AreaReinforcement areaReinforcement_1 = AreaReinforcement.Create(doc, element, curves, xyz, areaReinforcementTypeId, rebarBarTypeId, hookTypeId);
            areaReinforcement_1.get_Parameter(BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_1).Set(SpacingValue);
            areaReinforcement_1.get_Parameter(BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_1).Set(SpacingValue);
            areaReinforcement_1.get_Parameter(BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_2).Set(0);
            areaReinforcement_1.get_Parameter(BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_2).Set(0);
            areaReinforcement_1.get_Parameter(BuiltInParameter.REBAR_SYSTEM_ADDL_BOTTOM_OFFSET).Set(diameter);

            AreaReinforcement areaReinforcement_2 = AreaReinforcement.Create(doc, element, curves, xyz, areaReinforcementTypeId, rebarBarTypeId, hookTypeId);
            areaReinforcement_2.get_Parameter(BuiltInParameter.REBAR_SYSTEM_SPACING_TOP_DIR_2).Set(SpacingValue);
            areaReinforcement_2.get_Parameter(BuiltInParameter.REBAR_SYSTEM_SPACING_BOTTOM_DIR_2).Set(SpacingValue);
            areaReinforcement_2.get_Parameter(BuiltInParameter.REBAR_SYSTEM_ACTIVE_TOP_DIR_1).Set(0);
            areaReinforcement_2.get_Parameter(BuiltInParameter.REBAR_SYSTEM_ACTIVE_BOTTOM_DIR_1).Set(0);
            areaReinforcement_2.get_Parameter(BuiltInParameter.REBAR_SYSTEM_ADDL_TOP_OFFSET).Set(diameter);

        }
    }
}