        private static string FillTemplate(List<ClientListItem> clients, string fileName)
        {
            //Filled document file name
            var savedFileName = string.Empty;
            //Search template file in current directory
            var templateFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "templateFile.doc";
            
            object missing = System.Type.Missing;
            // Create Word application
            WORD._Application app = new WORD.Application();
            try
            {
                app.Visible = true;
                Print("Creating label document.");
                // Create new file
                WORD._Document doc = app.Documents.Open(templateFilePath);
                //Print("Creating app selection object");
                WORD.Selection selection = app.Selection;
                //If the template file contains tables
                if (selection.Tables.Count > 0)
                {
                    //Use first table
                    var tableToUse = selection.Tables[1];
                    //copy the empty table in the clipboard
                    WORD.Range range = tableToUse.Range;
                    range.Copy();
                    int rowIndex = 1;
                    int columnIndex = 1;
                    // loop over all the items to insert
                    foreach (ClientListItem parentCaregiver in clients)
                    {
                        // check if all the cells in the current row have been used
                        if (columnIndex > tableToUse.Columns.Count)
                        {
                            // if this is the case increment the row index and restart from the first column
                            columnIndex = 1;
                            rowIndex++;
                            // check if all the rows in the current table have been used
                            if (rowIndex > tableToUse.Columns.Count)
                            {
                                // if this is the case create a new table and restart from the first row
                                rowIndex = 1;
                                // first go to end of document
                                selection.EndKey(WORD.WdUnits.wdStory, WORD.WdMovementType.wdMove);
                                // then add page break
                                object breakType = WORD.WdBreakType.wdPageBreak; 
                                selection.InsertBreak(ref breakType);
                                // add a new table (initially with 1 row and one column) at the end of the document
                                // i.e. on the new page
                                WORD.Table tableCopy = doc.Tables.Add(selection.Range, 1, 1, ref missing, ref missing);
                                // paste the original empty table over the new one
                                tableCopy.Range.Paste();
                                // makes the copied table the one to use
                                tableToUse = tableCopy;
                            }
                        }
                        Print("Generating label to add to document.");
                        //Get label to add to document
                        var labelToAdd = string.Format("{0} {1},{6}{2},{6} {3}, {4} {5}", parentCaregiver.Parent1LastName, parentCaregiver.Parent1FirstName,
                            parentCaregiver.Parent1StreetAddress, parentCaregiver.Parent1City, parentCaregiver.Parent1State, parentCaregiver.Parent1Zip, Environment.NewLine);
                        //Get cell to set value
                        var tableCell = tableToUse.Cell(rowIndex, columnIndex);
                        //Set text in cell
                        tableCell.Range.Text = labelToAdd;
                        //Middle align text
                        tableCell.Range.ParagraphFormat.Alignment = WORD.WdParagraphAlignment.wdAlignParagraphCenter;
                        Print(string.Format("Label added {0} at {1}, {2} position.", labelToAdd, rowIndex, columnIndex));
                        columnIndex++;
                    }
                    
                }
                // Set file name to save
                savedFileName = fileName; // string.Format(@"{0}{1}{2}", Path.GetTempPath(), fileName, Path.GetExtension(templateFilePath));
                object fname = savedFileName;
                Print(string.Format("Saving new document at {0}", savedFileName));
                // SaveAs new file
                doc.SaveAs(ref fname, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                Print(string.Format("{0} saved successfully.", savedFileName));
                app.Documents.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception exc)
            {
                Print("Exception while generating label document");
                Print(exc.ToString());
                //Set file Name to empty string
                savedFileName = string.Empty;
            }
            finally
            {
                // Close Word application
                app.Quit(ref missing, ref missing, ref missing);
                Marshal.ReleaseComObject(app);
                app = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            //Return saved file name
            return savedFileName;
        }
