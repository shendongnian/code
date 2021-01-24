    using System.Web.Caching;
    
    private MonitorData getCachedData()
    {
      if (Cache["MonitorData"] == null)
        Cache.Add("MonitorData", LoadMonitorData(), null, DateTime.Now.AddMinutes(15)); // 15 minute cache expiration, as example
      return (MonitorData)Cache["MonitorData"];
    }
    
    public ActionResult ProjectPanes()
    {
        downloadedInfo = getCachedData();
        return PartialView("_ProjectPanes", downloadedInfo.MainPanel.OrderBy(o => o.Client).ToList());
    }
    
    public ActionResult ProjectData(string server)
    {
        downloadedInfo = getCachedData();
        return PartialView("_ProjectData", downloadedInfo.Information.Where(x => x.ServerName == server).ToList());
    }
    
    public ActionResult MainWindowMonitor()
    {
        downloadedInfo = getCachedData();
        return PartialView("_MainWindowMonitor", downloadedInfo.MonitorText);
    }
