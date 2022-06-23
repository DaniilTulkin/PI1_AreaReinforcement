using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using PI1_CORE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PI1_AreaReinforcement
{
    public partial class AreaReinforcementForm : System.Windows.Forms.Form
    {
        #region private members

        private UIDocument uidoc;

        private Document doc;

        private ElementId RebarBarTypeId { get;  set; }

        private double SpacingValue { get;  set; }

        private double WallRebarOutput { get;  set; }

        #endregion

        #region constructor

        public AreaReinforcementForm(UIDocument uidoc)
        {
            this.uidoc = uidoc;
            this.doc = uidoc.Document;

            InitializeComponent();
        }

        #endregion

        #region private methods

        private void AreaReinforcementForm_Load(object sender, EventArgs e)
        {
            PopulateRebarBarType();
        }

        private void cmbRebarBarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebarBarTypeId = ((KeyValuePair<string, ElementId>)cmbRebarBarType.SelectedItem).Value;
        }

        private void txtbSpacingValue_TextChanged(object sender, EventArgs e)
        {
            SpacingValue = UnitUtils.ConvertToInternalUnits(Convert.ToDouble(txtbSpacingValue.Text), DisplayUnitType.DUT_MILLIMETERS);
        }

        private void txtbWallRebarOutput_TextChanged(object sender, EventArgs e)
        {
            WallRebarOutput = UnitUtils.ConvertToInternalUnits(Convert.ToDouble(txtbWallRebarOutput.Text), DisplayUnitType.DUT_MILLIMETERS);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateRebarBarType()
        {
            var rebatBarTypes = new FilteredElementCollector(doc)
                .OfClass(typeof(RebarBarType));

            PopulateCommand.PopulateKeyValueList(rebatBarTypes, cmbRebarBarType);
        }

        #endregion

        #region public methods

        public CreateReinforcementData GetInformation()
        {
            var userInfo = new CreateReinforcementData()
            {
                RebarBarTypeId = this.RebarBarTypeId,
                SpacingValue = this.SpacingValue,
                WallRebarOutput = this.WallRebarOutput
            };

            return userInfo;
        }

        #endregion
    }
}
