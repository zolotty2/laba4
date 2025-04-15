namespace LAB4
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTypes = new Button();
            SuspendLayout();
            // 
            // btnTypes
            // 
            btnTypes.AutoSize = true;
            btnTypes.BackColor = SystemColors.ButtonFace;
            btnTypes.Font = new Font("Segoe UI", 14F);
            btnTypes.Location = new Point(12, 12);
            btnTypes.Name = "btnTypes";
            btnTypes.Size = new Size(328, 36);
            btnTypes.TabIndex = 0;
            btnTypes.Text = "Список типов аниме";
            btnTypes.UseVisualStyleBackColor = false;
            btnTypes.Click += BtnTypes_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1143, 630);
            Controls.Add(btnTypes);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormMain";
            Text = "Главная Форма";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTypes;
    }
}
