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
    public partial class HostForm : Form
    {
        private bool _closeForm = true;
        private DBContext _dbContext;
        private Queries _queries;

        private DialogResult MessageBoxResult { get; set; }
        MessageBoxButtons MessageBoxButtons = MessageBoxButtons.YesNo;

        // constructor
        public HostForm(DBContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _queries = new Queries(_dbContext);
            LoadListBox();
        }

        // appearence of items from DB in the list box
        public void LoadListBox()
        {
            DataTable dt = _queries.GetCategories();
            MessageBox.Show("amount of values in categories: "+dt.Rows.Count.ToString());
            listBox_Host.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listBox_Host.Items.Add(dr["CategoryName"].ToString()!);
            }
            textBox_Host_categories.Clear();
            return;
        }

        // handling closing form by the user
        private void HostForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_closeForm)
                Application.Exit();
        }

        // insert a category to DB and re-loading the list box
        private void button_Host_insertCategorie_Click(object sender, EventArgs e)
        {
            string? newCategory = textBox_Host_categories.Text.Trim();
            if (string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show("Please insert a category");
                return;
            }
            bool success = _queries.InsertCategory(newCategory);
            if (!success)
            {
                MessageBox.Show("can't insert that category");
                return;
            }
            LoadListBox();
            return;
        }

        // delete a category if it double clicked
        private void listBox_Host_DoubleClick(object sender, EventArgs e)
        {
            if(listBox_Host.SelectedItem != null)
            {
                MessageBoxResult = MessageBox.Show("Are you shure you want to delete the category?", "gdgdg", MessageBoxButtons);
                if (MessageBoxResult == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("lucky we are here :)");
                    return;
                }
                int userID = _queries.FindIDByCategoryName(listBox_Host.SelectedItem.ToString()!);
                if (userID != -1)
                {
                    bool ifDeleted = _queries.Delete(userID);
                    if (ifDeleted)
                    {
                        MessageBox.Show("deleted successfuly!");
                        LoadListBox();
                        textBox_Host_categories.Clear();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("could not delete the item");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("didn't find the category");
                    return;
                }
            }
            MessageBox.Show("you have to select a category");
            return;
        }
    }
}
