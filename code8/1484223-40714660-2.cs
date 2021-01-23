    private DateTime lastCheckTime = DateTime.Now.AddDays(-1);
    bool CheckLicense()
    {
        if (lastCheckTime.AddSeconds(10) < DateTime.Now)
        {
            return last status;
        }
        else 
        {
            lastCheckTime = DateTime.Now;
            // hardware access for license check
            return current status   
        }
    }
