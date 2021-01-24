    double delta = ax.Interval / 3d;
    for (double x = ax.Minimum; x <= ax.Maximum; x+=ax.Interval)
    {
        CustomLabel cl = new CustomLabel();
        cl.ToPosition = x + delta;
        cl.FromPosition = x - delta;
        cl.Text =  x.ToString();  // pick your text/format!
        if (x != 0) ax.CustomLabels.Add(cl);
    }
