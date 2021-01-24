    var response1 = httpClinet.GetAsync(str).Result;
    IEnumerable<PI> caseInfos1 = Enumerable.Empty<PI>();
    try
    {
        caseInfos1 = response1.Content.ReadAsAsync<IEnumerable<PI>>().Result;
    }
    catch (Exception ex)
    {
        try
        {
            m_Logging.Log(SharedLib.LoggingMode.Error, "IEnumerable failed, EXP:{0}", ex);
            var singleObject = response1.Content.ReadAsAsync<PI>().Result;
            if (singleObject != null)
            {
                m_Logging.Log(SharedLib.LoggingMode.Error, "singleObject succeeded...");
                caseInfos1 = new[] { singleObject };
            }
        }
        catch (Exception exp)
        {
            m_Logging.Log(SharedLib.LoggingMode.Error, "singleObject failed, EXP:{0}", exp);
        }
    }
