    private static string FillTemplate(List<ClientListItem> clients, string fileName)
    {
        //Filled document file name
        var savedFileName = string.Empty;
        //Search template file in current directory
        var templateFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "templateFile.doc";
    
        //#region Generate file for labels
    
        object missing = System.Type.Missing;
        // Create Word application
        WORD._Application app = new WORD.Application();
    
        try
        {
            Print("Creating label document.");
            // Create new file
            //WORD._Document doc = app.Documents.Open(templateFilePath);
            // Instead of creating a new file, just add our template to the document
            WORD._Document doc = app.Documents.Add(templateFilePath);
    
            //Print("Creating app selection object");
            WORD.Selection selection = app.Selection;
    
            //If the template file contains tables
            if (selection.Tables.Count > 0)
            {
                //Use first table
                //Table's are accessed with starting index as 1 not 0
                var tableToUse = selection.Tables[selection.Tables.Count];
    
                //Counter for number of parent caregivers inserted
                var counter = 0;
                //Number of parent caregivers
                var numberOfParentCaregivers = clients.Count;
                //Loop on each row
    
                int rowIndex = 1, columnIndex = 1;
    
                while (counter < numberOfParentCaregivers)
                {
                    if(columnIndex > tableToUse.Columns.Count)
                    {
                        // Reset column index if we have reached the last column
                        columnIndex = 1;
                        // And go to the next row
                        rowIndex++;
    
                        if(rowIndex > tableToUse.Rows.Count)
                        {
                            // Reset row index if we have reached the last row
                            rowIndex = 1;
                            // Go the the end of the document, add a page break and insert our empty table template
                            object startPoint = 0;
                            WORD.Range range = doc.Range(ref startPoint, ref missing);
                            range.Collapse(WORD.WdCollapseDir‌​ection.wdCollapseEnd‌​);
                            range.InsertBreak(WORD.WdBreakTyp‌​e.wdSectionBreakNext‌​Page);
                            range.InsertFile(templateFilePath);
                            // Assign the new inserted template table to our current table to use
                            tableToUse = range.Tables[selection.Tables.Count];
                        }
                    }
    
                    var parentCaregiver = clients[counter];
    
                    Print("Generating label to add to document.");
    
                    //Get label to add to document
                    var labelToAdd = string.Format("{0} {1},{6}{2},{6} {3}, {4} {5}", parentCaregiver.Parent1LastName, parentCaregiver.Parent1FirstName,
                        parentCaregiver.Parent1StreetAddress, parentCaregiver.Parent1City, parentCaregiver.Parent1State, parentCaregiver.Parent1Zip, Environment.NewLine);
    
                    //Print(string.Format("Adding label {0} at {1}, {2} position.", labelToAdd, rowIndex, columnIndex));
    
                    //Get cell to set value
                    var tableCell = tableToUse.Cell(rowIndex, columnIndex);
                    //Set text in cell
                    tableCell.Range.Text = labelToAdd;
                    //Middle align text
                    tableCell.Range.ParagraphFormat.Alignment = WORD.WdParagraphAlignment.wdAlignParagraphCenter;
    
                    Print(string.Format("Label added {0} at {1}, {2} position.", labelToAdd, rowIndex, columnIndex));
                    // Increate items counter and columns counter on each loop
                    counter++;
                    columnIndex++;
                }
            }
    
            // Set file name to save
            savedFileName = string.Format(@"{0}{1}{2}", Path.GetTempPath(), fileName, Path.GetExtension(templateFilePath));
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
