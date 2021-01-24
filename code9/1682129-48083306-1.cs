    private double result = 0.0;
    private void button1_Click(object sender, EventArgs e)
    {
       double b;
       if (Double.TryParse(textBox1.Text, out b))
       {
              result += b,
              textBox1.Text = "";
        }
        else
        {
           MessageBox.Show(@"Incorrect number");
        }
    }
        
    private void resultbutton2_Click(object sender, EventArgs e)
    {
       MessageBox.Show("Sum: " + result);
    }
