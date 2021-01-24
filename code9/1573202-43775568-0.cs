    ITerminalServicesManager manager = new TerminalServicesManager();
                using (ITerminalServer server = manager.GetRemoteServer(machineName))
                {
                    server.Open();
                    foreach (ITerminalServicesSession session in server.GetSessions())
                    {
                        if (string.IsNullOrEmpty(session.UserName))
                            continue;
                        if (session.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
                            sessionId = session.SessionId;
                    }
                }
