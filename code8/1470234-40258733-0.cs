    System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"observation_source=(\d+)");
    string url2 = re.Replace(Url, (m) =>
    {
      return m.Value.Replace(m.Groups[1].Value, "[ObsSource]");
    });
