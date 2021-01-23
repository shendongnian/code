    double[] judgesScore;
    private void computeScore_Click(object sender, EventArgs e)
    {
        judgesScore = new[]
        {
            Convert.ToDouble(textBox2.Text),
            Convert.ToDouble(textBox3.Text),
            Convert.ToDouble(textBox4.Text),
            Convert.ToDouble(textBox5.Text)
        };
    }
