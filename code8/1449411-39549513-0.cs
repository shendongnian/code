    public partial class frmWorkshopSelector : Form
    {
        public frmWorkshopSelector()
        {
            InitializeComponent();
          }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();     //When clicking the exit button, the program will close
        }
        private void btncalc_Click(object sender, EventArgs e)
        {
            int wsregistration = 0;
            int lcost = 0;
            const decimal DAYS = 3;
            //For the following if statements, depending on what workshop and location is selected,
            //their correstponding registration and lodging fees will be displayed
            {
                if (rbtHandlingStress.Checked == true)
                {
                    wsregistration = 1000;
                }
                else if (rbtSupervisionSkills.Checked == true)
                {
                    wsregistration = 1500;
                }
                else if (rbtTimeManagement.Checked == true)
                {
                    wsregistration = 800;
                }
                else
                MessageBox.Show("Please Select a Workshop");
                lblTotalCost.Text = "";
                lblLodgingCost.Text = "";
                lblRegistrationCost.Text = "";
                return;
            }
            {
                if (rbtAustin.Checked == true)
                {
                    lcost = 150;
                }
                else if (rbtChicago.Checked == true)
                {
                    lcost = 225;
                }
                else if (rbtDallas.Checked == true)
                {
                    lcost = 175;
                }
                else
                {
                    MessageBox.Show("Please Select a Location");
                    lblRegistrationCost.Text = " ";
                    lblTotalCost.Text = " ";
                    lblLodgingCost.Text = " ";
                    return;
                }
            }
            lblRegistrationCost.Text = wsregistration.ToString("C");
            lblLodgingCost.Text = lcost.ToString("C");
            lblTotalCost.Text = (wsregistration + (lcost * DAYS)).ToString("C");
    }
        private void btnReset_Click(object sender, EventArgs e)
        { //uncheks all radio buttons as well as clears out the previous calculations
            lblRegistrationCost.Text = "";
            lblLodgingCost.Text = "";
            lblTotalCost.Text = "";
            rbtHandlingStress.Checked = false;
            rbtSupervisionSkills.Checked = false;
            rbtTimeManagement.Checked = false;
            rbtAustin.Checked = false;
            rbtChicago.Checked = false;
            rbtDallas.Checked = false;
        }
    }
}
