    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
    	if (e.Button == System.Windows.Forms.MouseButtons.Right)
    	{
    		chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
    		chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
    	}
    }
