    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(textBox1.Text))
        {
            PopulateCombo(1);
        }
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(textBox1.Text))
        {
            PopulateCombo(2);
        }
    }
    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(textBox1.Text))
        {
            PopulateCombo(3);
        }
    }
    private void PopulateCombo(int textBoxID)
    {
        //With this you will get how many textBoxes have value
        int filledTextboxes = 0;
        filledTextboxes = (String.IsNullOrEmpty(textBox1.Text)) ? filledTextboxes++ : filledTextboxes;
        filledTextboxes = (String.IsNullOrEmpty(textBox2.Text)) ? filledTextboxes++ : filledTextboxes;
        filledTextboxes = (String.IsNullOrEmpty(textBox3.Text)) ? filledTextboxes++ : filledTextboxes;
        //With this you will run one code if only one textbox has value and other if more than one has value
        if(filledTextboxes == 1)
        {
            switch(textBoxID)
            {
                case 1:
                    //Populate comboBox with some value
                    break;
                case 2:
                    //Populate comboBox with some value
                    break;
                case 3:
                    //Populate comboBox with some value
                    break;
            }
        }
        else
        {
            //What happends when there are multiple textbox with value
        }
    }
