    public class Service
    {
        public static ExchangeService GetExchangeService(string username, string password, string ExchangeUrl)
        {
            var exchangeService = new ExchangeService(ExchangeVersion.Exchange2013);
            //WebService Uri
            try
            {
                exchangeService.Url = new Uri(ExchangeUrl);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("WebService Uri:" + ex));
            }
            //Credentials
            try
            {
                exchangeService.Credentials = new WebCredentials(username, password);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Credentials:" + ex));
            }
            return exchangeService;
        }
    }
     static void Main(string[] args)
        {
            ExchangeService service = null;
            service = Service.GetExchangeService("email@myexchangedomain.com", "mypassword", "https://outlook.office365.com/EWS/Exchange.asmx");
          var emailCreateCommand = CreateEmailCommand("name", "displayName", "alias");
          var res2 = ExecuteCommand(emailCreateCommand);
         }
    private static Command CreateEmailCommand(string name, string displayName, string alias)
        {
            Command myCommand = new Command("New-MailBox");
            myCommand.Parameters.Add("Shared", true);
            myCommand.Parameters.Add("Name", name);
            myCommand.Parameters.Add("DisplayName", displayName);
            myCommand.Parameters.Add("Alias", alias);
            return myCommand;
        }
    public static Collection<PSObject> ExecuteCommand(Command command)
        {
            string pass = "mypassword";
            System.Security.SecureString securePassword = new System.Security.SecureString();
            foreach (char c in pass.ToCharArray())
            {
                securePassword.AppendChar(c);
            }
            PSCredential newCred = new PSCredential("email@myexchangedomain.com", securePassword);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(
                new Uri("https://outlook.office365.com/PowerShell-LiveID"),
                "http://schemas.microsoft.com/powershell/Microsoft.Exchange",
                newCred);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(connectionInfo);
            myRunSpace.Open();
            Pipeline pipeLine = myRunSpace.CreatePipeline();
            pipeLine.Commands.Add(command);
            Collection<PSObject> result = pipeLine.Invoke();
            myRunSpace.Close();
            return result;
        }
