                    //If archive directory exists then delete it.
                    if (Directory.Exists(destination + "archive")) Directory.Delete(destination + "archive", true);
                    ZipFile.ExtractToDirectory(file_name, temp_destination);
                    
                    //look inside that folder for another zip file containing the data we need
                    var d = new DirectoryInfo(temp_destination);
                    FileInfo[] Files = d.GetFiles("*.zip"); //Get txt files
                    foreach (FileInfo file in Files)
                    {
                        
                        new Thread(() =>
                        {
                            Thread.CurrentThread.IsBackground = true;
                            ZipArchive zipArchive = ZipFile.OpenRead(temp_destination + file.Name);
                            foreach (ZipArchiveEntry entry in zipArchive.Entries)
                            {
                                string completeFileName = entry.FullName;
                                int idx = completeFileName.LastIndexOf('/');
                                if (completeFileName.Contains('/'))
                                {
                                    string foldername = completeFileName.Substring(0, idx);
                                    if (!Directory.Exists(destination + foldername))
                                        Directory.CreateDirectory(destination + foldername);
                                }
                                entry.ExtractToFile(Path.Combine(destination, entry.FullName), true);
                                Invoke(new Action(() =>
                                {
                                    rchtxtbx_output.AppendText("Extracting .....  " + entry.FullName);
                                    rchtxtbx_output.AppendText(Environment.NewLine);
                                    rchtxtbx_output.ScrollToCaret();
                                    Cursor.Current = Cursors.WaitCursor;
                                }));
                            }
                            zipArchive.Dispose();
