    public void AddPeak(GCPeak peak)
    {
        if (peak != null)
        {
            peaks.Add(peak.RunInformation.InjectionDateTime, peak);
        }
    }
