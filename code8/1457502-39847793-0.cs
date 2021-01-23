    private void word(DataSet Collection)
    {
        Word._Application objApp;
        Word._Document objDoc;
        try
        {
            object objMiss = System.Reflection.Missing.Value;
            object objEndOfDocFlag = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
    
            //Start Word and create a new document.
            objApp = new Word.Application();
            objApp.Visible = true;
           
            objDoc = objApp.Documents.Add(ref objMiss, ref objMiss,
                ref objMiss, ref objMiss);
    
            int tables = Collection.Tables.Count;
    
            for (int k = 0; k < tables; k++)
            {                
    
                int columns = Collection.Tables[k].Columns.Count;
                int rows = Collection.Tables[k].Rows.Count;
                string[] columnNames = Collection.Tables[k].Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray(); 
                //Insert a paragraph at the end of the document.
                Word.Paragraph objPara2; //define paragraph object
                object oRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of the page
                objPara2 = objDoc.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document
                objPara2.Range.Text = "Test Table Caption"; //add some text in paragraph
                objPara2.Format.SpaceAfter = 10; //defind some style
                objPara2.Range.InsertParagraphAfter(); //insert paragraph
                objPara2.Range.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                //Insert a n x n table, (table with n row and n column)
                Word.Table objTab1; //create table object
                Word.Range objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of document
                objTab1 = objDoc.Tables.Add(objWordRng, rows+1, columns, ref objMiss, ref objMiss); //add table object in word document
                objTab1.Range.ParagraphFormat.SpaceAfter = 6;
                int iRow, iCols;
                string strText;
    
                for (int jk = 1; jk <= columnNames.Count()-1; jk++)
                {
                    for (iCols = 0; iCols < columnNames.Count(); iCols++)
                    {
                        strText = columnNames[iCols];
                        objTab1.Cell(1, iCols+1).Range.Text = strText; //add some text to cell
                    }
    
                    objWordRng.InsertParagraphAfter();
                    int rowCol = 0;
                    
                    for (iRow = 2; iRow <= rows + 1; iRow++)
                    {
                        int cols = 0;                      
                        for (iCols = 1; iCols <= columns; iCols++)
                        {
                            strText = Convert.ToString(Collection.Tables[k].Rows[rowCol][cols]);
                            objTab1.Cell(iRow, iCols).Range.Text = strText;
                            cols++;
                           //add some text to cell
                        }
                        rowCol++;
                    }
                    objTab1.Rows[1].Range.Font.Bold = 1; //make first row of table BOLD
                  //  objTab1.Columns[1].Width = objApp.InchesToPoints(3); //increase first column width
    
                }
                //Add some text after table
                objWordRng = objDoc.Bookmarks.get_Item(ref objEndOfDocFlag).Range;
                objWordRng.InsertParagraphAfter(); //put enter in document
                objWordRng.InsertAfter("THIS IS THE SIMPLE WORD DEMO : THANKS YOU.");
    
                try
                {
                    // objTable.Borders.Shadow = true;
                    objTab1.Borders.Shadow = true;
                }
                catch
                {
                }
            }
            object szPath = "test.docx"; //your file gets saved with name 'test.docx'
            objDoc.SaveAs(ref szPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error occurred while executing code : " + ex.Message);
        }
        finally
        {
            //you can dispose object here
        }
    }     
