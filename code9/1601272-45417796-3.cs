      public class BaseController : Controller
    {
        public readonly string ApiBaseAdress = System.Configuration.ConfigurationManager.AppSettings["ApiBaseAddress"];
        public BaseController()
        {
            //Set as needed Servicepoint settings
            //string SecurityProtocolTypeFromConfig = System.Configuration.ConfigurationManager.AppSettings["SecurityProtocolType"];
            //SecurityProtocolType fromConfig;
            //Enum.TryParse(SecurityProtocolTypeFromConfig, out fromConfig);
            //ServicePointManager.SecurityProtocol = fromConfig;
            //possible ServicePoint setting needed in some cases.                    
            //ServicePointManager.Expect100Continue = false;
            //ServicePointManager.MaxServicePointIdleTime = 2000;
            //ServicePointManager.SetTcpKeepAlive(false, 1, 1);
        }
    }
