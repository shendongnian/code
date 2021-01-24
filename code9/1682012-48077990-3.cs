    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            int Number = Convert.ToInt32(textBox1.Text);
            double result = HalfNumber(Number);
            MessageBox.Show("Half of the number is " + result.ToString());
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
        double x = numberToUse / 2.0;
        return x;
    }
