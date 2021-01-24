    private double CalculateData(int F, double R, int N)
    {
        double P = F / (1 + R) * N;
        return P;
    
    }
    private void button1_Click(object sender, EventArgs e)
        {
        
            int n = int.Parse(sitTextBox.Text);
            int f = int.Parse(futureTextBox.Text);
            double r = double.Parse(intTextBox.Text);
        
            presentValuelabel.Text = CalculateData(f, r, n).ToString();
        }
