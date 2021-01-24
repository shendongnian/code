    private static void GetPasswordExpiredDate()
    {
        try
        {
            var userName = "";
            var password = "";
            var securePassword = new SecureString();
            var domainName = "";
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            Collection<PSObject> user = null;
            Collection<PSObject> passwordPolicy = null;
            // Create Initial Session State for runspace.
            InitialSessionState initialSession = InitialSessionState.CreateDefault();
            initialSession.ImportPSModule(new[] { "MSOnline" });
            // Create credential object.
            PSCredential credential = new PSCredential(userName, securePassword);
            // Create command to connect office 365.
            Command connectCommand = new Command("Connect-MsolService");
            connectCommand.Parameters.Add((new CommandParameter("Credential", credential)));
            // Create command to get office 365 users.
            Command getPasswordPolicy = new Command("Get-MsolPasswordPolicy");
            getPasswordPolicy.Parameters.Add(new CommandParameter("DomainName", domainName));
            //Command getUserCommand = new Command("$UserPrincipal=Get-MsolUser -UserPrincipalName 'user1@adfei.onmicrosoft.com'");
            Command getUserCommand = new Command("Get-MsolUser");
            getUserCommand.Parameters.Add(new CommandParameter("UserPrincipalName", "user1@adfei.onmicrosoft.com"));
            //Command getPasswordExpiredDate = new Command("$UserPrincipal.LastPasswordChangeTimestamp.AddDays($PasswordPolicy.ValidityPeriod)");
            using (Runspace psRunSpace = RunspaceFactory.CreateRunspace(initialSession))
            {
                // Open runspace.
                psRunSpace.Open();
                //Iterate through each command and executes it.
                foreach (var com in new Command[] { connectCommand, getUserCommand, getPasswordPolicy })
                {
                    var pipe = psRunSpace.CreatePipeline();
                    pipe.Commands.Add(com);
                    if (com.Equals(getUserCommand))
                        user = pipe.Invoke();
                    else if (com.Equals(getPasswordPolicy))
                        passwordPolicy = pipe.Invoke();
                    else
                        pipe.Invoke();
                }
                DateTime date =(DateTime) user[0].Properties["LastPasswordChangeTimestamp"].Value;
                UInt32 ValidityPeriod = (UInt32)passwordPolicy[0].Properties["ValidityPeriod"].Value;
                Console.WriteLine($"The password will be expired at {date.AddDays(ValidityPeriod)}");
                // Close the runspace.
                psRunSpace.Close();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
