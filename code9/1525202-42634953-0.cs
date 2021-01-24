                    System.Uri uri = new System.Uri("url link");
                    using (SvnClient client = new SvnClient())
                    {
                        try
                        {
                            // Get new timestamp
                            DateTime date = DateTime.Now;
                            string time = String.Format("{0:G}", date);
                            // To Get the Latest Revision on the Required SVN Folder
                            SvnInfoEventArgs info;
                            client.GetInfo(uri, out info);
                            // Prepare a PropertyArgs object with latest revision and a commit message;
                            SvnSetPropertyArgs args = new SvnSetPropertyArgs() { BaseRevision = info.Revision, LogMessage = "Sample msg for SVN commit" };
                            // Set property to file in the svn directory
                            client.RemoteSetProperty(uri, "svn:time", time, args);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Check out error!");
                        }
                    }
