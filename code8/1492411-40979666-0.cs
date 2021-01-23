                Outlook.MailItem Email = null;
                Outlook.Inspector actInspector = Outlook.Application.ActiveInspector();
                if (actInspector == null)
                {
                    Outlook.Explorer explorer = Outlook.Application.ActiveExplorer();
                    try
                    {
                        Email = explorer.GetType().InvokeMember("ActiveInlineResponse", System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.Public, null, explorer, null) as Outlook.MailItem;
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(explorer);
                    }
                }
                else
                {
                    try
                    {
                        Email = actInspector.CurrentItem as Outlook.MailItem;
                    }
                    finally
                    {
                        if (actInspector != null) Marshal.ReleaseComObject(actInspector);
                    }
                }
