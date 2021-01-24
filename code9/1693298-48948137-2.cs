    private void AlignAxes(Graphics3D g)
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
            var labels = (ArrayList)privateField.GetValue(tChart1.Axes.Left.Labels);
            tChart1.Axes.Right.Labels.Items.Clear();
            var gratestWidth = 0;
            for (var i = 0; i < labels.Count; i++)
            {
                var rect = (Rectangle)labels[i];
                tChart1.Axes.Right.Labels.Items.Add(
                                  tChart1.Axes.Right.CalcPosPoint(rect.Y + (rect.Height / 2)));
                var width = g.MeasureString(tChart1.Axes.Right.Labels.Font, 
                            tChart1.Axes.Right.Labels.Items
                            [tChart1.Axes.Right.Labels.Items.Count - 1].
                            Value.ToString(
                            tChart1.Axes.Right.Labels.ValueFormat)).
                            ToSize().Width;
                if (width > gratestWidth)
                {
                    gratestWidth = width;
                }
            }
            if (labels.Count > 0)
            {
                tChart1.Axes.Right.Labels.CustomSize = gratestWidth + 10;
            }
            else
            {
                tChart1.Axes.Right.Labels.CustomSize = 0;
            }
            tChart1.Axes.Right.Grid.DrawEvery = tChart1.Axes.Left.Grid.DrawEvery;
            tChart1.Refresh();
        }
    }  
