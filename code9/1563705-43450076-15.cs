    public void SetupTrainStopAxis(Chart chart)
    {
        Axis ay = chart.ChartAreas[0].AxisY;
        ay.LabelStyle.Font = new Font("Consolas", 8f);
        double totalDist = 0;
        for (int i = 0; i < TrainStops.Count; i++)
        {
            CustomLabel cl = new CustomLabel();
            cl.Text = TrainStops[i].Item1;
            cl.FromPosition = totalDist - 0.1d;
            cl.ToPosition = totalDist + 0.1d;
            totalDist += TrainStops[i].Item2;
            cl.ForeColor = TrainStops[i].Item3 == 1 ? Color.DimGray : Color.Black;
            ay.CustomLabels.Add(cl);
        }
        ay.Minimum = 0;
        ay.Maximum = totalDist;
        ay.MajorGrid.Enabled = false;
        ay.MajorTickMark.Enabled = false;
    }
