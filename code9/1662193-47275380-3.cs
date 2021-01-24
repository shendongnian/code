    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
    {
        //suposing you have this code
        int numrsa1 = (int)this.numericUpDown2.Value;
    
        //or add the rest 8 lines to your code
        if (IsPrimeNumber(numrsa1))
        {
            numericUpDown2.Value = numrsa1;
        }
        else
        {
            numericUpDown2.UpButton();
        }
    }
    
