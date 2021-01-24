    while (true) // hey, we are gentlemen after all...
    {
        String wt = waitingTime.text;
        if (String.IsNullOrWhiteSpace(wt))
        {
            Debug.LogWarning("No Input");
            continue;
        }
        Single t = Single.NaN;
        try
        {
            t = Single.Parse(wt);
        }
        catch
        {
            Debug.LogWarning("Parse Error");
            continue;
        }
        Debug.LogWarning("Waiting for: " + t.ToString() + "seconds...");
        // Do something
    }
