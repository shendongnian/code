    private void TChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
    {
      String tmp = "Multiline\nText\nAngle 45 Degree";
      
      g.RotateLabel(100, 150, tmp, 45);
    }
