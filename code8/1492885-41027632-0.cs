    public static class MyLogManager
    {
        static public NLog.LogFactory Factory1 = new LogFactory(new XmlLoggingConfiguration("nlogconfig1.xml"));
        static public NLog.LogFactory Factory2 = new LogFactory(new XmlLoggingConfiguration("nlogconfig2.xml"));
    }
