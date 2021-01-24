            ITerminalServicesManager manager = new TerminalServicesManager();
            using (ITerminalServer server = manager.GetRemoteServer(serverName))
            {
                server.Open();
                foreach (ITerminalServicesSession session in server.GetSessions())
                {
                     NTAccount account = session.UserAccount;
                    if (account != null)
                    {
                        if (account.ToString() == username)
                        {
                            Disconnect(serverName, session.SessionId);
                        }
                    }
                }
            }
