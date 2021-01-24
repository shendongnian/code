    private void adxPowerPointAppEvents_PresentationBeforeSave(object sender, ADXHostBeforeActionEventArgs e)
            {
                PowerPoint.Presentation pre = e.HostObject as PowerPoint.Presentation;
                try
                {
                    
                    if (pre.Saved == Microsoft.Office.Core.MsoTriState.msoFalse)
                    {
                        e.Cancel = true;
    
                        GCHandle handle = GCHandle.Alloc(pre.FullName);
                        IntPtr parameter = (IntPtr)handle;
    
    
                        this.SendMessage(MESSAGE_SAVE_PPT, parameter, IntPtr.Zero);
                        pre.Saved = Microsoft.Office.Core.MsoTriState.msoTrue;
                    }
                }
                catch(Exception ex)
                {
                    Log.Info("Exception while saving powerpoint : " + ex.StackTrace);
                    MessageBox.Show(ex.Message);
                }
                    return;
            }
    
    private void AddinModule_OnSavePowerPointMessage(object sender, AddinExpress.MSO.ADXSendMessageEventArgs e)
            {
                if (e.Message == MESSAGE_SAVE_PPT)
                {
                    PowerPoint.Presentation ppPre = null;
                    try
                    {
                        GCHandle handle = (GCHandle)e.WParam;
                        String fullName = (handle.Target as String);
    
                        ppPre = PowerPointApp.Presentations[fullName];
                        if (ppPre != null)
                        {
                            ppPre.Saved = Microsoft.Office.Core.MsoTriState.msoTrue;
                            //ppPre.SaveAs(ppPre.FullName, PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Microsoft.Office.Core.MsoTriState.msoTrue);
                            ppPre.Save();
    
    
                            Log.Info("Value of pre.name " + ppPre.Name);
                        }
                    }
                    catch (Exception exSavePpt)
                    {
                        Log.Info("Exception while saving powerpoint : " + exSavePpt.StackTrace);
                    }
                }
            }
