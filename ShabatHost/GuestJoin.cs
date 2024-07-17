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
    public partial class GuestJoin : Form
    {
        private bool _closeForm = true;
        private DBContext _dbContext;
        private Queries _queries;
        private FormHandler _formHandler;

        private DialogResult MessageBoxResult { get; set; }
        MessageBoxButtons MessageBoxButtons = MessageBoxButtons.YesNo;

        // constructor
        public GuestJoin(DBContext dbContext, FormHandler formHandler)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _queries = new Queries(_dbContext);
            LoadListBox();
            _formHandler = formHandler;

        }

        // handling closing form by the user
        private void GuestJoin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_closeForm)
                Application.Exit();
        }

        // get the list of guests from DB and re-loading the list box 
        public void LoadListBox()
        {
            DataTable dt = _queries.GetGuests();
            MessageBox.Show("amount of guests: " + dt.Rows.Count.ToString());
            listBox_GuestJoin.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listBox_GuestJoin.Items.Add(dr["GuestName"].ToString()!);
            }
            return;
        }

        // adding the guest to DB and to list box by re-loading and navigate to categories forms
        private void button_GuestJoin_add_Click(object sender, EventArgs e)
        {
            string? newGuest = textBox_GuestJoin_name.Text.Trim();
            if (string.IsNullOrEmpty(newGuest))
            {
                MessageBox.Show("Please enter your name");
                return;
            }
            bool success = _queries.InsertGuest(newGuest);
            if (!success)
            {
                MessageBox.Show("can't insert that guest");
                return;
            }
            int id = _queries.FindIDByGuestName(newGuest);
            if(id == -1)
            {
                MessageBox.Show("couldn't find the id of guest name");
                return;
            }
            LoadListBox();
            _closeForm = false;
            this.Close();
            _formHandler.ShowFirstCategory(id);
            return;
        }

        // chose the name in the list box by double click and navigates to categories forms
        private void listBox_GuestJoin_DoubleClick(object sender, EventArgs e)
        {
            MessageBoxResult = MessageBox.Show("Are you the person you just clicked", "gdgdg", MessageBoxButtons);
            if (MessageBoxResult == System.Windows.Forms.DialogResult.No)
            {
                MessageBox.Show("then enter your name please");
                return;
            }
            textBox_GuestJoin_name.Text = listBox_GuestJoin.SelectedItem.ToString()!;
            DialogResult res2 = MessageBox.Show("Do you want to enter to the category page?", "gdgdg", MessageBoxButtons);
            if(res2 == System.Windows.Forms.DialogResult.No)
            {
                MessageBox.Show("Allright then :)");
                return;
            }
            int id = _queries.FindIDByGuestName(textBox_GuestJoin_name.Text);
            if (id == -1)
            {
                MessageBox.Show("couldn't find the id of guest name you double clicked");
                return;
            }
            _closeForm = false;
            this.Close();
            _formHandler.ShowFirstCategory(id);
            return;
        }
    }
}
