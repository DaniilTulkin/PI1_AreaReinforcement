
namespace PI1_AreaReinforcement
{
    partial class AreaReinforcementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRebarBarType = new System.Windows.Forms.Label();
            this.lblSpacingValue = new System.Windows.Forms.Label();
            this.lblWallRebarOutput = new System.Windows.Forms.Label();
            this.cmbRebarBarType = new System.Windows.Forms.ComboBox();
            this.txtbSpacingValue = new System.Windows.Forms.TextBox();
            this.txtbWallRebarOutput = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRebarBarType
            // 
            this.lblRebarBarType.AutoSize = true;
            this.lblRebarBarType.Location = new System.Drawing.Point(14, 14);
            this.lblRebarBarType.Margin = new System.Windows.Forms.Padding(5);
            this.lblRebarBarType.Name = "lblRebarBarType";
            this.lblRebarBarType.Size = new System.Drawing.Size(140, 13);
            this.lblRebarBarType.TabIndex = 0;
            this.lblRebarBarType.Text = "Тип арматурного стержня";
            // 
            // lblSpacingValue
            // 
            this.lblSpacingValue.AutoSize = true;
            this.lblSpacingValue.Location = new System.Drawing.Point(14, 66);
            this.lblSpacingValue.Margin = new System.Windows.Forms.Padding(5);
            this.lblSpacingValue.Name = "lblSpacingValue";
            this.lblSpacingValue.Size = new System.Drawing.Size(49, 13);
            this.lblSpacingValue.TabIndex = 1;
            this.lblSpacingValue.Text = "Шаг, мм";
            // 
            // lblWallRebarOutput
            // 
            this.lblWallRebarOutput.AutoSize = true;
            this.lblWallRebarOutput.Location = new System.Drawing.Point(14, 119);
            this.lblWallRebarOutput.Margin = new System.Windows.Forms.Padding(5);
            this.lblWallRebarOutput.Name = "lblWallRebarOutput";
            this.lblWallRebarOutput.Size = new System.Drawing.Size(122, 13);
            this.lblWallRebarOutput.TabIndex = 2;
            this.lblWallRebarOutput.Text = "Выпуск для стены, мм";
            // 
            // cmbRebarBarType
            // 
            this.cmbRebarBarType.FormattingEnabled = true;
            this.cmbRebarBarType.Location = new System.Drawing.Point(14, 35);
            this.cmbRebarBarType.Margin = new System.Windows.Forms.Padding(5);
            this.cmbRebarBarType.Name = "cmbRebarBarType";
            this.cmbRebarBarType.Size = new System.Drawing.Size(150, 21);
            this.cmbRebarBarType.TabIndex = 3;
            this.cmbRebarBarType.SelectedIndexChanged += new System.EventHandler(this.cmbRebarBarType_SelectedIndexChanged);
            // 
            // txtbSpacingValue
            // 
            this.txtbSpacingValue.Location = new System.Drawing.Point(14, 89);
            this.txtbSpacingValue.Margin = new System.Windows.Forms.Padding(5);
            this.txtbSpacingValue.Name = "txtbSpacingValue";
            this.txtbSpacingValue.Size = new System.Drawing.Size(150, 20);
            this.txtbSpacingValue.TabIndex = 4;
            this.txtbSpacingValue.TextChanged += new System.EventHandler(this.txtbSpacingValue_TextChanged);
            // 
            // txtbWallRebarOutput
            // 
            this.txtbWallRebarOutput.Location = new System.Drawing.Point(14, 140);
            this.txtbWallRebarOutput.Name = "txtbWallRebarOutput";
            this.txtbWallRebarOutput.Size = new System.Drawing.Size(150, 20);
            this.txtbWallRebarOutput.TabIndex = 5;
            this.txtbWallRebarOutput.TextChanged += new System.EventHandler(this.txtbWallRebarOutput_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(50, 168);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // AreaReinforcementForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 201);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtbWallRebarOutput);
            this.Controls.Add(this.txtbSpacingValue);
            this.Controls.Add(this.cmbRebarBarType);
            this.Controls.Add(this.lblWallRebarOutput);
            this.Controls.Add(this.lblSpacingValue);
            this.Controls.Add(this.lblRebarBarType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AreaReinforcementForm";
            this.ShowIcon = false;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.AreaReinforcementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRebarBarType;
        private System.Windows.Forms.Label lblSpacingValue;
        private System.Windows.Forms.Label lblWallRebarOutput;
        private System.Windows.Forms.ComboBox cmbRebarBarType;
        private System.Windows.Forms.TextBox txtbSpacingValue;
        private System.Windows.Forms.TextBox txtbWallRebarOutput;
        private System.Windows.Forms.Button btnOK;
    }
}