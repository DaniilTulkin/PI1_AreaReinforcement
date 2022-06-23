using Autodesk.Revit.DB;

namespace PI1_AreaReinforcement
{
    public class CreateReinforcementData
    {
        #region public members

        public ElementId RebarBarTypeId { get; set; }

        public double SpacingValue { get; set; }

        public double WallRebarOutput { get; set; }

        #endregion

        #region constructor

        public CreateReinforcementData()
        {

        }

        #endregion
    }
}