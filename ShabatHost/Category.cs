using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShabatHost
{
    public partial class Category : Form
    {
        private bool _closeForm = true;
        private DBContext _dbContext;
        private Queries _queries;
        private FormHandler _formHandler;
        private string _categoryName;
        private int _guestID;
        private int _categoryID;

        private DialogResult MessageBoxResult { get; set; }
        MessageBoxButtons MessageBoxButtons = MessageBoxButtons.YesNo;

        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem deleteRowMenuItem;

        // constructor
        public Category(DBContext dbContext, string name, int id, FormHandler formHandler)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _queries = new Queries(_dbContext);
            _categoryName = name;
            label_Category_categoryName.Text = _categoryName;
            _formHandler = formHandler;
            _guestID = id;
            _categoryID = _queries.FindIDByCategoryName(_categoryName);
            dataGridView_bottom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_top.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadOtherGuestsDataGridView();
            LoadMyDataGridView();
            InitializeContextMenu();
        }

        // navigating to previous category form - if thats the first it navigates to the last category form
        private void button_Category_right_Click(object sender, EventArgs e)
        {
            _formHandler.Previous();
        }

        // navigating to next category form - if thats the last it navigates to the first category form
        private void button_Category_left_Click(object sender, EventArgs e)
        {
            _formHandler.Next();
        }

        // handling closing form by user
        private void Category_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_closeForm)
                Application.Exit();
        }

        // get from DB the list of food ordered by other guests and re-loading the top dataGridView
        private void LoadOtherGuestsDataGridView()
        {
            DataTable dt = _queries.GetOtherGuestsFoodName(_guestID, _categoryID);
            dataGridView_top.DataSource = dt;
        }

        // get from DB the list of food ordered by current guest and re-loading the bottom dataGridView
        private void LoadMyDataGridView()
        {
            DataTable dt = _queries.GetFoodName(_guestID, _categoryID);
            dataGridView_bottom.DataSource = dt;
        }

        // adding to DB the selected food to this guest and re-loading the bottom dataGridView
        private void button_Category_add_Click(object sender, EventArgs e)
        {
            string newFood = textBox_Category_foodName.Text.Trim();
            if (string.IsNullOrEmpty(newFood))
            {
                MessageBox.Show("enter a food please");
                return;
            }
            bool success = _queries.InsertFood(newFood, _guestID, _categoryID);
            if (!success)
            {
                MessageBox.Show("can't insert that food to DB");
                return;
            }
            LoadMyDataGridView();

        }

        private void dataGridView_bottom_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView_bottom.ClearSelection();
                dataGridView_bottom.Rows[e.RowIndex].Selected = true;
                dataGridView_bottom.CurrentCell = dataGridView_bottom.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void InitializeContextMenu()
        {
            contextMenuStrip = new ContextMenuStrip();
            deleteRowMenuItem = new ToolStripMenuItem("Delete Row");
            contextMenuStrip.Items.Add(deleteRowMenuItem);
            dataGridView_bottom.ContextMenuStrip = contextMenuStrip;
            deleteRowMenuItem.Click += DeleteRowMenuItem_Click;
        }

        // delete by right click on the mouse food row from DB and from dataGridView
        private void DeleteRowMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxResult = MessageBox.Show("Are you shure you want to delete the food?", "gdgdg", MessageBoxButtons);
            if (MessageBoxResult == System.Windows.Forms.DialogResult.No)
            {
                MessageBox.Show("lucky we are here haha");
                return;
            }
            if (dataGridView_bottom.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView_bottom.SelectedRows[0].Index;
                if (rowIndex >= 0)
                {
                    var cellValue = dataGridView_bottom.Rows[rowIndex].Cells[0].Value;
                    string rowText = cellValue?.ToString() ?? string.Empty;
                    if (string.IsNullOrEmpty(rowText))
                    {
                        MessageBox.Show("to delete you need to chose a row with value");
                        return;
                    }
                    bool success = _queries.DeleteFood(rowText, _guestID, _categoryID);
                    if (!success)
                    {
                        MessageBox.Show("Couldn't delete the row :(");
                        return;
                    }
                    MessageBox.Show("deleted from DB successfuly!");
                    dataGridView_bottom.Rows.RemoveAt(rowIndex);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}
