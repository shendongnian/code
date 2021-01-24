    double last_x_max, last_x_min, last_y_max, last_y_min;
    private bool trendGraphControl_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
    {
        // Save the zoom values
        last_x_max = sender.GraphPane.XAxis.Scale.Max;
        last_x_min = sender.GraphPane.XAxis.Scale.Min;
        last_y_max = sender.GraphPane.YAxis.Scale.Max;
        last_y_min = sender.GraphPane.YAxis.Scale.Min;
        return false;
    }
    private void trendGraphControl_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
    {
        if (newState.Type == ZoomState.StateType.Zoom) {
            double new_x_max = sender.GraphPane.XAxis.Scale.Max;
            double new_x_min = sender.GraphPane.XAxis.Scale.Min;
            double new_y_max = sender.GraphPane.YAxis.Scale.Max;
            double new_y_min = sender.GraphPane.YAxis.Scale.Min;
            selectPointsInArea(new_x_max, new_x_min, new_y_max, new_y_min);
            sender.GraphPane.XAxis.Scale.Max = last_x_max;
            sender.GraphPane.XAxis.Scale.Min = last_x_min;
            sender.GraphPane.YAxis.Scale.Max = last_y_max;
            sender.GraphPane.YAxis.Scale.Min = last_y_min;
        }
    }
