using CozurOfficial.AutoClicker.Language;
using SuchByte.MacroDeck.GUI.CustomControls;
using System.Windows.Forms;

namespace CozurOfficial.AutoClicker.GUI
{
    partial class ClickingCoordinatesConfigurator
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCoordinateX = new System.Windows.Forms.Label();
            this.labelCoordinateY = new System.Windows.Forms.Label();
            this.textBoxCoordinateX = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.textBoxCoordinateY = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.chkLeftClick = new System.Windows.Forms.CheckBox();
            this.chkRightClick = new System.Windows.Forms.CheckBox();
            // 
            // textBoxCoordinateX
            // 
            this.textBoxCoordinateX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxCoordinateX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxCoordinateX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCoordinateX.Icon = null;
            this.textBoxCoordinateX.Location = new System.Drawing.Point(130, 8);
            this.textBoxCoordinateX.MaxCharacters = 32767;
            this.textBoxCoordinateX.Multiline = true;
            this.textBoxCoordinateX.Name = "textBoxCoordinateX";
            this.textBoxCoordinateX.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.textBoxCoordinateX.PasswordChar = false;
            this.textBoxCoordinateX.PlaceHolderColor = System.Drawing.Color.Gray;
            this.textBoxCoordinateX.PlaceHolderText = PluginLanguageManager.PluginStrings.TexCoordinateX;
            this.textBoxCoordinateX.ReadOnly = false;
            this.textBoxCoordinateX.SelectionStart = 0;
            this.textBoxCoordinateX.Size = new System.Drawing.Size(130, 22);
            this.textBoxCoordinateX.TabIndex = 0;
            this.textBoxCoordinateX.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // textBoxCoordinateY
            //
            this.textBoxCoordinateY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxCoordinateY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxCoordinateY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCoordinateY.Icon = null;
            this.textBoxCoordinateY.Location = new System.Drawing.Point(130, 38);
            this.textBoxCoordinateY.MaxCharacters = 32767;
            this.textBoxCoordinateY.Multiline = true;
            this.textBoxCoordinateY.Name = "textBoxCoordinateY";
            this.textBoxCoordinateY.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.textBoxCoordinateY.PasswordChar = false;
            this.textBoxCoordinateY.PlaceHolderColor = System.Drawing.Color.Gray;
            this.textBoxCoordinateY.PlaceHolderText = PluginLanguageManager.PluginStrings.TexCoordinateY;
            this.textBoxCoordinateY.ReadOnly = false;
            this.textBoxCoordinateY.SelectionStart = 0;
            this.textBoxCoordinateY.Size = new System.Drawing.Size(130, 22);
            this.textBoxCoordinateY.TabIndex = 0;
            this.textBoxCoordinateY.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // chkLeftClick
            //
            this.chkLeftClick.AutoSize = true;
            this.chkLeftClick.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkLeftClick.Location = new System.Drawing.Point(10, 70);
            this.chkLeftClick.Name = "chkLeftClick";
            this.chkLeftClick.Size = new System.Drawing.Size(66, 23);
            this.chkLeftClick.TabIndex = 0;
            this.chkLeftClick.Text = PluginLanguageManager.PluginStrings.TexLeftClick;
            this.chkLeftClick.UseVisualStyleBackColor = true;
            // 
            // chkRightClick
            //
            this.chkRightClick.AutoSize = true;
            this.chkRightClick.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkRightClick.Location = new System.Drawing.Point(10, 100);
            this.chkRightClick.Name = "chkRightClick";
            this.chkRightClick.Size = new System.Drawing.Size(66, 23);
            this.chkRightClick.TabIndex = 0;
            this.chkRightClick.Text = PluginLanguageManager.PluginStrings.TexRightClick;
            this.chkRightClick.UseVisualStyleBackColor = true;
            // 
            // AutoClickConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCoordinateX);
            this.Controls.Add(this.labelCoordinateY);
            this.Controls.Add(this.textBoxCoordinateX);
            this.Controls.Add(this.textBoxCoordinateY);
            this.Controls.Add(this.chkLeftClick);
            this.Controls.Add(this.chkRightClick);
            this.Name = "AutoClickConfigurator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void StartTrackingMousePosition()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (sender, e) =>
            {
                var mousePosition = Cursor.Position;
                // 
                // labelCoordinateX
                // 
                this.labelCoordinateX.AutoSize = true;
                this.labelCoordinateX.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.labelCoordinateX.Location = new System.Drawing.Point(10, 10);
                this.labelCoordinateX.Name = "labelCoordinateX";
                this.labelCoordinateX.Size = new System.Drawing.Size(58, 13);
                this.labelCoordinateX.TabIndex = 4;
                this.labelCoordinateX.Text = "Mouse X: " + mousePosition.X;
                // 
                // labelCoordinateY
                // 
                this.labelCoordinateY.AutoSize = true;
                this.labelCoordinateY.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                this.labelCoordinateY.Location = new System.Drawing.Point(10, 40);
                this.labelCoordinateY.Name = "labelCoordinateY";
                this.labelCoordinateY.Size = new System.Drawing.Size(58, 13);
                this.labelCoordinateY.TabIndex = 4;
                this.labelCoordinateY.Text = "Mouse Y: " + mousePosition.Y;
            };
            timer.Start();
        }



        #endregion

        private System.Windows.Forms.Label labelCoordinateX;
        private System.Windows.Forms.Label labelCoordinateY;
        private RoundedTextBox textBoxCoordinateX;
        private RoundedTextBox textBoxCoordinateY;
        private System.Windows.Forms.CheckBox chkLeftClick;
        private System.Windows.Forms.CheckBox chkRightClick;
    }
}

