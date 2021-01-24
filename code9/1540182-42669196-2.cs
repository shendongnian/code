                fileOpenInProgress = true;
                workerXLPwdDialogCheck.RunWorkerAsync();
    
                StringBuilder resultsOut = new StringBuilder();
    
                if (MsOfficeHelper.IsPasswordProtected(fileName))
                {
                    while ((excelApp.Workbooks.Count == 0) && (!allPasswordUsed))
                    {
                        // Open workbook - trying each password from password list in turn
                        foreach (var excelPassword in excelPasswords)
                        {
                            try
                            {
    
                                excelWorkbook = excelApp.Workbooks.Open(Filename: fileName, UpdateLinks: Excel.XlUpdateLinks.xlUpdateLinksNever, Password: excelPassword);
                                allPasswordUsed = true;
                                resultsOut = resultsOut.AppendLine(fileName + " - Opened");
                            }
                            catch (Exception WTF)
                            {
                                //MessageBox.Show(WTF.Message);
                            }
                        }
    
                        // Open workbook - trying each password from password list in turn
                        foreach (var excelPassword in excelPasswords)
                        {
                            try
                            {
                                excelWorkbook = excelApp.Workbooks.Open(Filename: fileName, UpdateLinks: Excel.XlUpdateLinks.xlUpdateLinksNever, Password: excelPassword.ToLower());
                                allPasswordUsed = true;
                                resultsOut = resultsOut.AppendLine(fileName + " - Opened");
                                //
                            }
                            catch (Exception WTF)
                            {
                                //MessageBox.Show(WTF.Message);
                            }
                        }
    
                        allPasswordUsed = true;
                        resultsOut = resultsOut.AppendLine(fileName + " - All known passwords used - Unable to Open File");
                    }
                }
                else
                {
                    // Open Workbook - no password required
                    excelWorkbook = excelApp.Workbooks.Open(Filename: fileName, UpdateLinks: Excel.XlUpdateLinks.xlUpdateLinksNever);
                    resultsOut = resultsOut.AppendLine(fileName + " - Opened");
                }
    
                // Assuming there is an openwork book object
                // check to see if it contains links and attempt to update them.
                if (excelApp.Workbooks.Count > 0)
                {
                    excelWorkbook = excelApp.ActiveWorkbook;
    #pragma warning disable IDE0019 // Use pattern matching
                    Array olinks = excelWorkbook.LinkSources(Excel.XlLink.xlExcelLinks) as Array;
    #pragma warning restore IDE0019 // Use pattern matching
                    if (olinks != null)
                    {
                        if (olinks.Length > 0)
                        {
                            resultsOut = resultsOut.AppendLine("  " + fileName + " - " + olinks.Length.ToString() + " links.");
                            foreach (var olink in olinks)
                            {
                                oldLink = olink.ToString();
    
                                // Search through list of linked files to find the oldLink
                                foreach (LinkedFile linkedFile in linkedFiles)
                                {
                                    if (oldLink == linkedFile.OldLink)
                                    {
                                        newLink = linkedFile.NewLink;
                                        break;
                                    }
                                }
    
                                try
                                {
    
                                    excelWorkbook.ChangeLink(Name: oldLink, NewName: newLink, Type: Excel.XlLinkType.xlLinkTypeExcelLinks);
                                    resultsOut = resultsOut.AppendLine("  SUCCESS - ChangeLink from " + oldLink + " to " + newLink);
                                    Application.DoEvents();
                                }
                                catch (Exception whoopsy)
                                {
                                    resultsOut = resultsOut.AppendLine("  FAILURE - ChangeLink from " + oldLink + " to " + newLink);
                                    Application.DoEvents();
                                }
    
                                //resultsOut = resultsOut.AppendLine("  " + oldLink);
    
                            }  // End For loop
                        }
                        else
                        {
                            resultsOut = resultsOut.AppendLine("  No links.");
                        }
    
                    }
    
                    excelWorkbook.Close(SaveChanges: true);
                    resultsOut = resultsOut.AppendLine(fileName + " - Closed");
                    resultsOut = resultsOut.AppendLine(" ");
    
                }
    
                // Stop the background worker that checks for the existence of a 
                // Excel Password Dialog
                fileOpenInProgress = false;
                workerXLPwdDialogCheck.CancelAsync();
                return resultsOut.ToString();
