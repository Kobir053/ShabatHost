namespace ShabatHost
{
    partial class GuestJoin
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
            label1 = new Label();
            label2 = new Label();
            textBox_GuestJoin_name = new TextBox();
            button_GuestJoin_add = new Button();
            listBox_GuestJoin = new ListBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(350, 40);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 0;
            label1.Text = "Welcome to our Hostel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(351, 89);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 1;
            label2.Text = "Please enter your name";
            // 
            // textBox_GuestJoin_name
            // 
            textBox_GuestJoin_name.Location = new Point(372, 137);
            textBox_GuestJoin_name.Name = "textBox_GuestJoin_name";
            textBox_GuestJoin_name.Size = new Size(125, 27);
            textBox_GuestJoin_name.TabIndex = 2;
            // 
            // button_GuestJoin_add
            // 
            button_GuestJoin_add.Location = new Point(386, 183);
            button_GuestJoin_add.Name = "button_GuestJoin_add";
            button_GuestJoin_add.Size = new Size(94, 29);
            button_GuestJoin_add.TabIndex = 3;
            button_GuestJoin_add.Text = "Add me";
            button_GuestJoin_add.UseVisualStyleBackColor = true;
            button_GuestJoin_add.Click += button_GuestJoin_add_Click;
            // 
            // listBox_GuestJoin
            // 
            listBox_GuestJoin.FormattingEnabled = true;
            listBox_GuestJoin.Location = new Point(351, 240);
            listBox_GuestJoin.Name = "listBox_GuestJoin";
            listBox_GuestJoin.Size = new Size(162, 124);
            listBox_GuestJoin.TabIndex = 4;
            listBox_GuestJoin.DoubleClick += listBox_GuestJoin_DoubleClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(201, 396);
            label3.Name = "label3";
            label3.Size = new Size(480, 20);
            label3.TabIndex = 5;
            label3.Text = "if your'e already a guest you can double click your name and get start :)";
            // 
            // GuestJoin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(listBox_GuestJoin);
            Controls.Add(button_GuestJoin_add);
            Controls.Add(textBox_GuestJoin_name);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GuestJoin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GuestJoin";
            FormClosed += GuestJoin_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox_GuestJoin_name;
        private Button button_GuestJoin_add;
        private ListBox listBox_GuestJoin;
        private Label label3;
    }
}