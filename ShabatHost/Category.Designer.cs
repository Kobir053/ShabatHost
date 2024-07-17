namespace ShabatHost
{
    partial class Category
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
            label_Category_categoryName = new Label();
            dataGridView_top = new DataGridView();
            textBox_Category_foodName = new TextBox();
            button_Category_add = new Button();
            dataGridView_bottom = new DataGridView();
            button_Category_right = new Button();
            button_Category_left = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_top).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_bottom).BeginInit();
            SuspendLayout();
            // 
            // label_Category_categoryName
            // 
            label_Category_categoryName.AutoSize = true;
            label_Category_categoryName.Location = new Point(354, 9);
            label_Category_categoryName.Name = "label_Category_categoryName";
            label_Category_categoryName.Size = new Size(131, 20);
            label_Category_categoryName.TabIndex = 0;
            label_Category_categoryName.Text = "Name of Category";
            // 
            // dataGridView_top
            // 
            dataGridView_top.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_top.Location = new Point(183, 32);
            dataGridView_top.Name = "dataGridView_top";
            dataGridView_top.ReadOnly = true;
            dataGridView_top.RowHeadersWidth = 51;
            dataGridView_top.Size = new Size(465, 126);
            dataGridView_top.TabIndex = 1;
            // 
            // textBox_Category_foodName
            // 
            textBox_Category_foodName.Location = new Point(262, 178);
            textBox_Category_foodName.Name = "textBox_Category_foodName";
            textBox_Category_foodName.PlaceholderText = "enter food";
            textBox_Category_foodName.Size = new Size(125, 27);
            textBox_Category_foodName.TabIndex = 3;
            // 
            // button_Category_add
            // 
            button_Category_add.Location = new Point(460, 178);
            button_Category_add.Name = "button_Category_add";
            button_Category_add.Size = new Size(94, 29);
            button_Category_add.TabIndex = 4;
            button_Category_add.Text = "add food";
            button_Category_add.UseVisualStyleBackColor = true;
            button_Category_add.Click += button_Category_add_Click;
            // 
            // dataGridView_bottom
            // 
            dataGridView_bottom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_bottom.Location = new Point(183, 213);
            dataGridView_bottom.Name = "dataGridView_bottom";
            dataGridView_bottom.ReadOnly = true;
            dataGridView_bottom.RowHeadersWidth = 51;
            dataGridView_bottom.Size = new Size(465, 134);
            dataGridView_bottom.TabIndex = 5;
            dataGridView_bottom.CellMouseDown += dataGridView_bottom_CellMouseDown;
            // 
            // button_Category_right
            // 
            button_Category_right.Location = new Point(442, 364);
            button_Category_right.Name = "button_Category_right";
            button_Category_right.Size = new Size(94, 29);
            button_Category_right.TabIndex = 6;
            button_Category_right.Text = ">>>>";
            button_Category_right.UseVisualStyleBackColor = true;
            button_Category_right.Click += button_Category_right_Click;
            // 
            // button_Category_left
            // 
            button_Category_left.Location = new Point(326, 364);
            button_Category_left.Name = "button_Category_left";
            button_Category_left.Size = new Size(94, 29);
            button_Category_left.TabIndex = 7;
            button_Category_left.Text = "<<<<";
            button_Category_left.UseVisualStyleBackColor = true;
            button_Category_left.Click += button_Category_left_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(286, 421);
            label1.Name = "label1";
            label1.Size = new Size(283, 20);
            label1.TabIndex = 8;
            label1.Text = "you can delete your choises by right click!";
            // 
            // Category
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button_Category_left);
            Controls.Add(button_Category_right);
            Controls.Add(dataGridView_bottom);
            Controls.Add(button_Category_add);
            Controls.Add(textBox_Category_foodName);
            Controls.Add(dataGridView_top);
            Controls.Add(label_Category_categoryName);
            Name = "Category";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Category";
            FormClosed += Category_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView_top).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_bottom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Category_categoryName;
        private DataGridView dataGridView_top;
        private TextBox textBox_Category_foodName;
        private Button button_Category_add;
        private DataGridView dataGridView_bottom;
        private Button button_Category_right;
        private Button button_Category_left;
        private Label label1;
    }
}