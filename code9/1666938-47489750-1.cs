    private void button1_Click(object sender, EventArgs e)
    {
        double[] array = new double[5] { 0.25, 0.4, 0.5, 0.6, 0.7 };
    
        double TargetNumber = Double.Parse(textBox1.Text);
        var nearest = FindNearest(array, TargetNumber);
    
        label1.Text = nearest.ToString(); // nulls are printed as empty string
    }
