    foreach (string dep in Directory.GetDirectories(plantFolder1)) // different departements
                                {
                                    string depFolder1 = plantFolder1 + dep.Remove(0, plantFolder1.Length);
                                    string depFolder2 = depFolder1.Replace(subReplica1, subReplica2); ;
                                    Thread.Sleep(50);
                                    // Synchronization of 2 Folders
                                    FileSyncProvider providerA = new FileSyncProvider(Guid.NewGuid(), depFolder1, filter, options);
                                    bool exists = Directory.Exists(depFolder2);
                                    if (!exists)
                                        Directory.CreateDirectory(depFolder2);
                                    FileSyncProvider providerB = new FileSyncProvider(Guid.NewGuid(), depFolder2, filter, options);
                                    providerA.DetectChanges();
                                    providerB.DetectChanges();
                                    Thread.Sleep(50);
                                    SyncOrchestrator agent = new SyncOrchestrator();
                                    agent.LocalProvider = providerA;
                                    agent.RemoteProvider = providerB;
                                    agent.Direction = SyncDirectionOrder.Upload;
                                    agent.Synchronize();
                                    Thread.Sleep(50);
                                }
