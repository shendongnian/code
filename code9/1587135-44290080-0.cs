     protected void Page_Load(object sender, EventArgs e)
        {
            GV_addition.Visible = RadioButtonList1.SelectedIndex == 0;
            GV_termination.Visible = RadioButtonList1.SelectedIndex == 1;
        }
 
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
               
        }
