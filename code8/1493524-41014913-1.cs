            protected void Button1_Click(object sender, EventArgs e)
            {
                Random random = new Random();
    
                var radioButtonNumber = random.Next(RadioButtonList1.Items.Count);
    
                RadioButtonList1.SelectedIndex = radioButtonNumber;
    
                RadioButtonListClick(radioButtonNumber);
    
            }
    
            private void RadioButtonListClick(int number)
            {
                switch (number)
                {
                    case 0:
                        // Call the function realted to radio button 0 in your case.
                        break;
                        .
                        .
                        .
    
                }
            }
