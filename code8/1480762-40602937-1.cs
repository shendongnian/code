        using NLog;
        using NLog.Config;
        using NLog.Targets;
        using System.Xml;
    ...
    
    public static Logger logger = LogManager.GetCurrentClassLogger();
    
    ....   
        public static void ConfigNLog()
                {
           
                string xml = @"
                <nlog xmlns=""http://www.nlog-project.org/schemas/NLog.xsd""
                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                    <targets>
                        <target name=""file"" xsi:type=""File""
                                layout=""${longdate} ${logger} ${message}"" 
                                fileName=""${specialfolder:ApplicationData}\FindAlike\NewMails.txt""
                                keepFileOpen=""false""
                                encoding=""iso-8859-2"" />
                    </targets>
                    <rules>
                        <logger name=""*""  writeTo=""file"" />
                    </rules>
                </nlog>";
    
                StringReader sr = new StringReader(xml);
                XmlReader xr = XmlReader.Create(sr);
                XmlLoggingConfiguration config = new XmlLoggingConfiguration(xr, null);
                NLog.LogManager.Configuration = config;
            }
