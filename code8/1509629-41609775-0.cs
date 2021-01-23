                using (PowerShell ps = PowerShell.Create())
                {
                    if (remoteRunspacePool != null)
                        ps.RunspacePool = remoteRunspacePool;
                    else
                        ps.Runspace = remoteRunSpace;
                    Command myCommand = new Command(getPolicyExtractionCommand(dummy));
                    Command myCommand2 = new Command("Select-Object");
                    ps.Commands.AddCommand(myCommand);
                    var props = new string[] { "Identity", "Description", "Name" };
                    myCommand2.Parameters.Add("Property", getPropertiesForPolicies(dummy));
                    ps.Commands.AddCommand(myCommand2);
                    PSDataCollection<PSObject> execRes = await Task.Factory.FromAsync(beingRes, ps.EndInvoke).ConfigureAwait(false);
                    Collection<PSObject> processes = execRes.ReadAll();
                }
