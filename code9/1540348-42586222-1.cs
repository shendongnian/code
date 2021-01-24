    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
        ChartArea ca1 = chart1.ChartAreas[0];
        ChartArea ca2 = chart1.ChartAreas[1];
        Axis ax1 = ca1.AxisX;
        Axis ax2 = ca2.AxisX;
        if (e.Axis== ax1) { ax2.ScaleView.Size = ax1.ScaleView.Size;
                            ax2.ScaleView.Position = ax1.ScaleView.Position;  }
        if (e.Axis== ax2) { ax1.ScaleView.Size = ax2.ScaleView.Size;
                            ax1.ScaleView.Position = ax2.ScaleView.Position;   }
    }
