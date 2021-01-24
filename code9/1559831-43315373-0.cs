    private static Collection<PSObject> ExcutePowershellCommands()
    {
        try
        {
            var userName = ";
            var password = "";
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
        
            Collection<PSObject> user = null;
            // Create Initial Session State for runspace.
            InitialSessionState initialSession = InitialSessionState.CreateDefault();
            initialSession.ImportPSModule(new[] { "MSOnline" });
            // Create credential object.
            PSCredential credential = new PSCredential(userName, securePassword);
            // Create command to connect office 365.
            Command connectCommand = new Command("Connect-MsolService");
            connectCommand.Parameters.Add((new CommandParameter("Credential", credential)));
            // Create command to get office 365 users.
            Command getUserCommand = new Command("Get-MsolUser");
            getUserCommand.Parameters.Add(new CommandParameter("UserPrincipalName", "user1@adfei.onmicrosoft.com"));
            using(Runspace psRunSpace = RunspaceFactory.CreateRunspace(initialSession))
            {
                // Open runspace.
                psRunSpace.Open();
                //Iterate through each command and executes it.
                foreach (var com in new Command[] { connectCommand, getUserCommand })
                {
                    var pipe = psRunSpace.CreatePipeline();
                    pipe.Commands.Add(com);
                    // Execute command and generate results and errors (if any).
                    Collection<PSObject> results = pipe.Invoke();
                    user = results;
                
                }
                // Close the runspace.
                psRunSpace.Close();
            }
            Console.WriteLine($"{user[0].Properties["LastPasswordChangeTimestamp"].Value}");
            return user;
        }
        catch (Exception)
        {
            throw;
        }
    }
