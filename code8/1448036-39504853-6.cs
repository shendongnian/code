     DataTable dtDataSource = new DataTable();
    
            string[] fileContent = File.ReadAllLines(@"..\\Book1.csv");
    
            if (fileContent.Count() > 0)
            {
                //Create data table columns dynamically
                string[] columns = fileContent[0].Split(',');
    
                for (int i = 0; i < columns.Count(); i++)
                {
                    dtDataSource.Columns.Add(columns[i]);
                }
    
                //Add row data dynamically
                for (int i = 1; i < fileContent.Count(); i++)
                {
                    string[] rowData = fileContent[i].Split(',');
                    string[] realRowData = new string[columns.Count()];
                    StringBuilder collaboration = new StringBuilder();
                    int v = 0;
    
                    //this region solves the problem of a cell containing ",".
                    #region CommaSepProblem
                    for (int j = 0, K = 0; j < rowData.Count(); j++, K++)
                    {
    
                        //After splitting the line with commas. The cells containing commas will also be splitted.
                        //Fact: if a cell contains special symbol in excel that cell will be saved in .csv contained in quotes E.g A+B will be saved "A+B" or A,B will be saved as "A,B"
                        //Our code splits everything where comma is found. So solution is:
                        //Logic: After splitting if a string contains even number of DoubleQuote  then its perfect cell otherwise, it is splitted in multiple cells of array.
    
                        if ((rowData[j].Count(x => x == '"') % 2 == 0))//checks if the string contains even number of DoubleQuotes
                        {
                            realRowData[K] = quotesLogic((rowData[j]));
    
                        }
                        else if ((rowData[j].Count(x => x == '"') % 2 != 0))//If Number of DoubleQuotes  are ODD
                        {
                            int c = rowData[j].Count(x => x == '"');
                            v = j;
    
                            while (c % 2 != 0)//Go through all the next array cell till it makes EVEN Number of DoubleQuotes.
                            {
                                collaboration.Append(rowData[j] + ",");
                                j++;
                                c += rowData[j].Count(x => x == '"');
    
                            }
    
                            collaboration.Append(rowData[j]);
                            realRowData[K] = quotesLogic(collaboration.ToString());
                        }
                        else { continue; }
                    }
                    #endregion
                    dtDataSource.Rows.Add(realRowData);
                }
                if (dtDataSource != null)
                {
                   
                    dataGrid1.ItemsSource = dtDataSource.DefaultView;
                }
            }
