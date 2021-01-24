       private void button19_Click(object sender, EventArgs e)  //decimal point ( . ) 
        {
            if (txtResult.Text == "0"|| txtResult.Text.IndexOf('.') ==-1) // to find the empty string or to find the index of .
            {
                txtResult.Text += ".";
                creatingNewNumber = false;
            }
            else
            {
               //
                 
            }
           
        }
