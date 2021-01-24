    public async Task<ReturnType> MyMethod()
    {
        // Get the listener
        UserNotificationListener listener = UserNotificationListener.Current;
    
        // And request access to the user's notifications (must be called from UI thread)
        UserNotificationListenerAccessStatus accessStatus = await listener.RequestAccessAsync();
    }
