    private void numericUpDown5_ValueChanged(object sender, EventArgs e)
    {
        Axis ay = chart2.ChartAreas[0].AxisY;
        int oy = (int)numericUpDown5.Value;
        if (radioButton1.Checked)  ay.IntervalOffset = oy;
        if (radioButton2.Checked)  ay.Maximum = oy;
        if (radioButton3.Checked)  ay.Minimum = oy;
    }
    private void rbAy_CheckedChanged(object sender, EventArgs e)
    {
        Axis ay = chart2.ChartAreas[0].AxisY;
        if (sender == radioButton1) numericUpDown5.Value = (decimal)ay.IntervalOffset;
        if (sender == radioButton2) numericUpDown5.Value = (decimal)ay.Maximum;
        if (sender == radioButton3) numericUpDown5.Value = (decimal)ay.Minimum;
    }
    
