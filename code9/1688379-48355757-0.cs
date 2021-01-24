    private void rBtn102_Click(object sender, EventArgs e)
    {
		RadioButton rb = sender as RadioButton;
		if (rb == null)
		  return; // This is error
		  
        if (rb.Checked)
        {
            sDepartment = (string)rb.Tag;
            updateExampleLabel();
            updateChooseOffer();
        }
    }
