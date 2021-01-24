    //for (int i = 0; i < count; i++)
    for (int i=count-1; i>=0; i--)
    {
        // index out of range check
        if (download.Count() > i )
        {
            // Remove
            if (excluded.Contains(download[i]))
            {
                download.RemoveAt(i);
                download.TrimExcess();
            }
        }
    }
