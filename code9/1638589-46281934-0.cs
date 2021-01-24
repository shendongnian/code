       MAPIFolder f;
        int retries = 0;
        while (!connected && retries < 2)
        {
            doUpdateStatus("Connecting");
            try
            {
                app = new Application();
                NameSpace ns = app.GetNamespace("MAPI");
                f = ns.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                doUpdateStatus("Connected to outlook");
                doUpdateStatus("Walking Outlook Folders .. Please wait");
                try
                {
                    doUpdateStatus("");
                    if (DoSync)
                    {
                        try
                        {
                            doUpdateStatus("Syncing");
                            SyncObject _syncObj = null;
                            _syncObj = ns.SyncObjects.AppFolders;
                            _syncObj.SyncEnd += _syncObj_SyncEnd;
                            ns.SendAndReceive(false);
                            syncing = true;
                            _syncObj.Start();
                            while (syncing)
                            {
                                Thread.Sleep(10);
                            }
                            connected = true;
                        }
                        catch
                        {
                            doUpdateStatus("Sync failed");
                        }
                        finally
                        {
                            syncing = false;
                        }
                    }
                    else
                    {
                        doUpdateStatus("Outlook sync disabled");
                        connected = true;
                    }
                }
                catch
                {
                    doUpdateStatus("Unable to connect to Outlook and Load folders");
                    app.Quit();
                     retries++;
                    Thread.Sleep(5000);
                }
            }
            catch
            {
                doUpdateStatus("Unable to connect to Outlook");
                if (app!=null) app.Quit();
               retries++;
                Thread.Sleep(5000);
            }
        }
        private static void _syncObj_SyncEnd()
        {
            syncing = false;
        }
