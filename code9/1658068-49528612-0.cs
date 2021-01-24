    static void App_BeforeSaveDocument(Microsoft.Office.Interop.Word.Document document, ref bool saveAsUI, ref bool cancel)
                {
                    if (th != null)
                        th.Abort();
                    th = new Thread(backupOnSave);
                    th.IsBackground = true;
                    th.Start(document);
                }
