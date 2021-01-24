    var mChart = view.FindViewById<PieChart>(Resource.Id.chart1);
    List<PieEntry> entries = new List<PieEntry>();
    entries.Add(new PieEntry(18.5f, "Sony"));
    entries.Add(new PieEntry(26.7f, "Huawei"));
    entries.Add(new PieEntry(24.0f, "Apple"));
    entries.Add(new PieEntry(30.8f, "Samsung"));
    PieDataSet set = new PieDataSet(entries, "");
    List<Integer> colors = new List<Integer>();
    foreach (Integer c in ColorTemplate.VordiplomColors)
        colors.Add(c);
    foreach (Integer c in ColorTemplate.JoyfulColors)
        colors.Add(c);
    foreach (Integer c in ColorTemplate.ColorfulColors)
        colors.Add(c);
    foreach (Integer c in ColorTemplate.LibertyColors)
        colors.Add(c);
    foreach (Integer c in ColorTemplate.PastelColors)
        colors.Add(c);
    colors.Add((Integer)ColorTemplate.HoloBlue);
    set.Colors = colors;
    PieData data = new PieData(set);
    mChart.Data = data;
    mChart.Invalidate(); // refresh
    return view;
