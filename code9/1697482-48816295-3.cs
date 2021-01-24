        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string domain = "myDomain";
                string userName = "myUserName";
                string password = "NotAPassword"
                //Using NEW_CREDENTIALS is the same as RunAs with the /netonly switch set.  Local computer login is based on the 
                //current user.  While the impersonated account will be used for remote access to resources on the network.  
                //Therefore authentication across the domain.
                //Per MSDN, NEW_CREDENTIALS should only work with the WINNT50 provider type.  However, I have verified this to work with Default.
                //I'm just not sure of the long-term implications since MS made a point to specify this.
                using (Impersonator.LogonUser(domain, userName, password, LogonType.NEW_CREDENTIALS, LogonProvider.LOGON32_PROVIDER_WINNT50))
                {
                    //This will show the currently logged on user (machine), because NEW_CREDENTIALS doesn't alter this, only remote access
                    Console.WriteLine("Current user...{0}", WindowsIdentity.GetCurrent().Name);  
                    using (BillMarkContext dbContext = new BillMarkContext())
                    {
                        //Read each bill mark object
                        foreach (BillMarkCode code in dbContext.BillMarkCodes.AsEnumerable<BillMarkCode>())
                        {
                            Console.WriteLine(code.Code);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
