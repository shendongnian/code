    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var result = new List<DateString>();
        var baseUri = (Uri)e.Argument;
        var countryCodes = ExtractCountries();
        foreach (var cc in countryCodes)
        {
            if (backgroundWorker1.CancellationPending)
            {
               e.Cancel = true;
               return;
            }
            result.Add(ExtractDateAndTime(new Uri(baseUri, "?region=" + cc));
        }
        e.Result = result;
    }
