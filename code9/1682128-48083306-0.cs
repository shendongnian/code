    private int i = 0;
    private double[] a = new double[2];
    private void button1_Click(object sender, EventArgs e)
    {
       double b;
       if (Double.TryParse(textBox1.Text, out b))
       {
          a[i] = b;
          i++;
          textBox1.Text = "";
        }
        else
        {
           MessageBox.Show(@"Incorrect number");
        }
    }
    
    private void resultbutton2_Click(object sender, EventArgs e)
    {
       double sum = a[0] + a[1];
       MessageBox.Show("Sum: " + sum);
    }
