    private bool _redrawAgain = false;
    private void AlignAxes()
    {
        if (_redrawAgain)
        {
            _redrawAgain = false;
        }
        else
        {
            _redrawAgain = true;
            var tmpl = new AxisLabels(tChart1.Axes.Left);
            var privateField = tmpl.GetType().GetField("labelPos", 
                               BindingFlags.NonPublic | BindingFlags.Instance);
            var labelPos = (ArrayList)privateField.GetValue(tChart1.Axes.Left.Labels);
            tChart1.Axes.Right.Labels.Items.Clear();
            for (var i = 0; i < labelPos.Count; i++)
            {
                var rect = (Rectangle)labelPos[i];
                tChart1.Axes.Right.Labels.Items.Add(
                                  tChart1.Axes.Right.CalcPosPoint(rect.Y + (rect.Height / 2)));
            }
            tChart1.Axes.Right.Grid.DrawEvery = tChart1.Axes.Left.Grid.DrawEvery;
            tChart1.Refresh();
        }
    }
