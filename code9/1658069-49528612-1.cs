    internal static void backupOnSave(object obj)
            {
                try
                {
                    Application app = obj as Application;
                    if (app == null || app.ActiveDocument == null)
                    {
                        return;
                    }
                    Microsoft.Office.Interop.Word.Document document = app.ActiveDocument;
                    if (!tempData.ContainsKey(document.FullName))
                        return;
                    var loopTicks = 2000;
    
                    while (true)
                    {
                        Thread.Sleep(loopTicks);
                        if (document.Saved)
                        {
                            if (!tempData.ContainsKey(document.FullName))
                                break;
                            var p = tempData[document.FullName];
                            var f = new FileInfo(p.FileFullName);
    
                            if (f.LastWriteTime != p.LastWriteTime)//changed, should create new backup
                            {
                                BackupFile(p, f);
                                p.LastWriteTime = f.LastWriteTime;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.write(ex);
                }
            }
