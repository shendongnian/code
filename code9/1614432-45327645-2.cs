    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(textBox1.Text))
        {
            PopulateCombo(1);
        }
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(textBox2.Text))
        {
            PopulateCombo(2);
        }
    }
    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(textBox3.Text))
        {
            PopulateCombo(3);
        }
    }
    private void PopulateCombo(int textBoxID)
        {
            //With this you will get how many textBoxes have value
            int filledTextboxes = 0;
            if(!String.IsNullOrEmpty(textBox1.Text))
            {
                filledTextboxes++;
            }
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                filledTextboxes++;
            }
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                filledTextboxes++;
            }
            //With this you will run one code if only one textbox has value and other if more than one has value
            if(filledTextboxes == 1)
            {
                switch(textBoxID)
                {
                    case 1:
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add("TextBox1");
                        break;
                    case 2:
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add("TextBox2");
                        break;
                    case 3:
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add("TextBox3");
                        break;
                }
            }
            else
            {
                comboBox1.Items.Clear();
                MessageBox.Show(String.Format("All items cleared because there are {0} boxes with value", filledTextboxes));
            }
        }
