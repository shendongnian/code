    List<double> y_n = new List<double>();
    List<double> var_map = new List<double>();
    List<double> var_fa_map = new List<double>();
    for (int k = 0; k < y_0.Count; k++)
    {
        y_n.Add(y_0[k] - i * inc);
        var_map.Add(Math.Min(Math.Max(y_n[k], 0), 1));
        var_fa_map.Add(not_edge_map[k] * var_map[k]);
    }
