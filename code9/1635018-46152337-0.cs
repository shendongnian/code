     for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ProductA = dt.Rows[i].ItemArray[0].ToString();
                    string Output = "";
                    string ProductB = "";
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (j == 0)
                        {
                            ProductB = dt.Columns[j + 1].ColumnName;
                             Output =  dt.Rows[i][j+1].ToString();
                        }
                        else
                        {
                            ProductB = dt.Columns[j+1].ColumnName;
                            Output = dt.Rows[i][j+1].ToString();
    
                        }
    
                        dt1.Rows.Add(ProductA, ProductB, Output);
    
                    }
    
                }
