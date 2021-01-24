    using LogInForm;
    namespace DriverSide
    {
	    public partial class Form1 : Form
        {
            public Form1()
		    {
			    InitializeComponent();
		    }
            private void _btnAccept_Click(object sender, EventArgs e)
            {
                UserOnTrip testWindow = new UserOnTrip();
                testWindow.Show();
            }
        }
    }
