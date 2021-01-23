        foreach (TableDef tb in clsDataSource.mydb.TableDefs)
            {
                   if (tb.Attributes == 0 && tb.Name == myTable.Name)
                    {
                        clsDataSource.mydb.TableDefs[myTable.Name].Fields.Append(myField);
                        myTable.Fields.Append(myField);
                        clsDataSource.mydb.TableDefs.Append(myTable);
                    }
                    else
                    {
                        MessageBox.Show("This field already exists");
                    }                
            }//end foreach
         
