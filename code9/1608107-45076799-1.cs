    private void CheckQueue(object dummy)
    {
        // The dummy is null, its there because it is a Timer event.
        AppIP.Connect(50);
        AppInfo appInfo;
        while(AppQ.TryDequeue(out appInfo))
        {
            // Process the appInfo
        }
    }
