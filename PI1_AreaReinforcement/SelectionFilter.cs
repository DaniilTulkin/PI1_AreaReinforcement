using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace PI1_AreaReinforcement
{
    class SelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            switch (elem.Category.Id.IntegerValue)
            {
                case (int)BuiltInCategory.OST_Walls:
                    return true;
                case (int)BuiltInCategory.OST_Floors:
                    return true;
                case (int)BuiltInCategory.OST_StructuralFoundation:
                    return true;
                default:
                    return false;
            }
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
