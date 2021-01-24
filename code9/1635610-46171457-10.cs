    foreach (ITrackable counter in this.TrackingCounters)
    {
        if (counter.ReaderID == 0 || counter.ReaderID == readingData.ReaderID)
        {
            counter.IncreaseOne();
        }
    }
