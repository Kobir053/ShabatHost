namespace ShabatHost
{
    partial class HostForm
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
            button_Host_insertCategorie = new Button();
            label1 = new Label();
            textBox_Host_categories = new TextBox();
            listBox_Host = new ListBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // button_Host_insertCategorie
            // 
            button_Host_insertCategorie.BackColor = Color.ForestGreen;
            button_Host_insertCategorie.ForeColor = Color.WhiteSmoke;
            button_Host_insertCategorie.Location = new Point(348, 135);
            button_Host_insertCategorie.Name = "button_Host_insertCategorie";
            button_Host_insertCategorie.Size = new Size(125, 40);
            button_Host_insertCategorie.TabIndex = 0;
            button_Host_insertCategorie.Text = "ADD";
            button_Host_insertCategorie.UseVisualStyleBackColor = false;
            button_Host_insertCategorie.Click += button_Host_insertCategorie_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(303, 30);
            label1.Name = "label1";
            label1.Size = new Size(220, 42);
            label1.TabIndex = 1;
            label1.Text = "Please insert categories";
            // 
            // textBox_Host_categories
            // 
            textBox_Host_categories.Location = new Point(329, 75);
            textBox_Host_categories.Multiline = true;
            textBox_Host_categories.Name = "textBox_Host_categories";
            textBox_Host_categories.Size = new Size(164, 41);
            textBox_Host_categories.TabIndex = 2;
            // 
            // listBox_Host
            // 
            listBox_Host.FormattingEnabled = true;
            listBox_Host.Location = new Point(329, 209);
            listBox_Host.Name = "listBox_Host";
            listBox_Host.Size = new Size(164, 144);
            listBox_Host.TabIndex = 3;
            listBox_Host.DoubleClick += listBox_Host_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(233, 390);
            label2.Name = "label2";
            label2.Size = new Size(355, 20);
            label2.TabIndex = 4;
            label2.Text = "You can always double click the category to delete :)";
            // 
            // HostForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(listBox_Host);
            Controls.Add(textBox_Host_categories);
            Controls.Add(label1);
            Controls.Add(button_Host_insertCategorie);
            Name = "HostForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HostForm";
            FormClosed += HostForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Host_insertCategorie;
        private Label label1;
        private TextBox textBox_Host_categories;
        private ListBox listBox_Host;
        private Label label2;
    }
}