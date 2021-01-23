        List<String> existingTables = new List<String>();
        foreach (TableDef tb in clsDataSource.mydb.TableDefs)
            {
                   if (tb.Attributes == 0 && tb.Name == myTable.Name)
                    {
                        clsDataSource.mydb.TableDefs[myTable.Name].Fields.Append(myField);
                        myTable.Fields.Append(myField);
                        clsDataSource.mydb.TableDefs.Append(myTable);
                    }         
                    else {       
                        existingTables.Add(MyTable.Name.ToString());
                    }      
            }//end foreach
        foreach (var el in existingTables){
               MessageBox.Show("This table already exists: {0}", el)
        }//end foreach
