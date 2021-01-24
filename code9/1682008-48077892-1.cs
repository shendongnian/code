    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            int Number = Convert.ToInt32(textBox1.Text);
            double myHalfNumber = HalfNumber(Number);
            MessageBox.Show("Half of the number is " +myHalfNumber.ToString());
    
            textBox1.Focus();
            textBox1.SelectAll();
     
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    
    }
    
    private double HalfNumber(int numberToUse)
    {      
        return numberToUse / 2.0;
    }
