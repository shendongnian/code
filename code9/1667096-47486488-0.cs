	var regex = new System.Text.RegularExpressions.Regex(@"00:\d{2}:\d{2}:\d{2}");
    foreach (var item in l.Items)
    {
        if (regex.IsMatch(item))
        {
            item =  TimeSpan.Parse(item).TotalMinutes.ToString();
        }
    }
