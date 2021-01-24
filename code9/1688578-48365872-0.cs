    public void createProject_Click(object sender, EventArgs e)
    {
        sChoosedOfferPath = comboBoxOfferPath.Text;
        
        control objControl = new control();
        if (objControl.controlProject())
        {
            MessageBox.Show("ths is true");
        }
    }
