namespace Minesweeper
{
    partial class CustomGame
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
            this.components = new System.ComponentModel.Container();
            this.Start_custom = new System.Windows.Forms.Button();
            this.CustomX = new System.Windows.Forms.NumericUpDown();
            this.Custom_cancel = new System.Windows.Forms.Button();
            this.CustomY = new System.Windows.Forms.NumericUpDown();
            this.CustomMines = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MinesError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CustomX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomMines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinesError)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_custom
            // 
            this.Start_custom.Location = new System.Drawing.Point(148, 164);
            this.Start_custom.Name = "Start_custom";
            this.Start_custom.Size = new System.Drawing.Size(75, 23);
            this.Start_custom.TabIndex = 0;
            this.Start_custom.Text = "Start";
            this.Start_custom.UseVisualStyleBackColor = true;
            this.Start_custom.Click += new System.EventHandler(this.Start_custom_Click);
            // 
            // CustomX
            // 
            this.CustomX.Location = new System.Drawing.Point(117, 31);
            this.CustomX.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CustomX.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.CustomX.Name = "CustomX";
            this.CustomX.Size = new System.Drawing.Size(120, 20);
            this.CustomX.TabIndex = 1;
            this.CustomX.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // Custom_cancel
            // 
            this.Custom_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Custom_cancel.Location = new System.Drawing.Point(33, 164);
            this.Custom_cancel.Name = "Custom_cancel";
            this.Custom_cancel.Size = new System.Drawing.Size(75, 23);
            this.Custom_cancel.TabIndex = 2;
            this.Custom_cancel.Text = "Cancel";
            this.Custom_cancel.UseVisualStyleBackColor = true;
            // 
            // CustomY
            // 
            this.CustomY.Location = new System.Drawing.Point(117, 69);
            this.CustomY.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CustomY.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.CustomY.Name = "CustomY";
            this.CustomY.Size = new System.Drawing.Size(120, 20);
            this.CustomY.TabIndex = 3;
            this.CustomY.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CustomMines
            // 
            this.CustomMines.Location = new System.Drawing.Point(117, 106);
            this.CustomMines.Maximum = new decimal(new int[] {
            399,
            0,
            0,
            0});
            this.CustomMines.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.CustomMines.Name = "CustomMines";
            this.CustomMines.Size = new System.Drawing.Size(120, 20);
            this.CustomMines.TabIndex = 4;
            this.CustomMines.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.CustomMines.Validating += new System.ComponentModel.CancelEventHandler(this.CustomMines_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y Field";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mines";
            // 
            // MinesError
            // 
            this.MinesError.ContainerControl = this;
            // 
            // CustomGame
            // 
            this.AcceptButton = this.Start_custom;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Custom_cancel;
            this.ClientSize = new System.Drawing.Size(261, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomMines);
            this.Controls.Add(this.CustomY);
            this.Controls.Add(this.Custom_cancel);
            this.Controls.Add(this.CustomX);
            this.Controls.Add(this.Start_custom);
            this.Name = "CustomGame";
            this.Text = "Custom";
            ((System.ComponentModel.ISupportInitialize)(this.CustomX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomMines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinesError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_custom;
        private System.Windows.Forms.NumericUpDown CustomX;
        private System.Windows.Forms.Button Custom_cancel;
        private System.Windows.Forms.NumericUpDown CustomY;
        private System.Windows.Forms.NumericUpDown CustomMines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider MinesError;
    }
}