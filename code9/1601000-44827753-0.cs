    //Prevent multiple clicks in 1 second.
    public static int MIN_CLICK_DELAY_TIME = 1000;
    private long lastClickTime = 0;
    bt.Click += ViewClickHandler;
    public void ViewClickHandler(object o, System.EventArgs a)
    {
        long currentTime = Calendar.Instance.TimeInMillis;
        if (currentTime - lastClickTime > MIN_CLICK_DELAY_TIME)
        {
             lastClickTime = currentTime;
             OnNoDoubleClick();
        }
    }
    protected void OnNoDoubleClick()
    {
        (new DownloadAsyncTask()).Execute();
    }
