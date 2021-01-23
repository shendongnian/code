    if (res.Headers.AllKeys.Contains("Vary"))
        {
            res.Headers["Vary"] = "Accept";
        }
        else
        {
            res.Headers.Add("Vary", "Accept");
        }
