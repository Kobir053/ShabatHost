namespace ShabatHost
{
    public partial class Form1 : Form
    {
        private bool _closeForm = true;
        private DBContext _dbContext;
        private FormHandler _formHandler;

        // constructor
        public Form1(DBContext dbContext, FormHandler formHandler)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _formHandler = formHandler;
        }

        // I am Host
        private void button2_Click(object sender, EventArgs e)
        {
            _closeForm = false;
            _formHandler.Show("HostForm", _dbContext);
        }

        // I am Guest
        private void button1_Click(object sender, EventArgs e)
        {
            _closeForm = false;
            _formHandler.Show("GuestJoin", _dbContext);
        }

        // handling closing form by the user
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_closeForm)
                Application.Exit();
        }
    }
}
