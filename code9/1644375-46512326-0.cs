    // Only for demonstration purposes, no error checks:
                // This code will only work as long as the table "Records002" does not exist
                string id = "002";
                // First create an new database if necessary
                Catalog cat = OpenDatabase();
     
                // Create a new table "Records" using ADOX ...
                Table table = new Table();
                table.Name = "Records" + id;
                cat.Tables.Append(table);
     
                // Add Column "RecordsID" with Autoincrement
                ADOX.Column col = new Column();
                col.Name = "RecordsID";
                col.ParentCatalog = cat;
                col.Type = ADOX.DataTypeEnum.adInteger;
                col.Properties["Nullable"].Value = false;
                col.Properties["AutoIncrement"].Value = true;
                table.Columns.Append(col);
     
                
     
                // Make "Records" the primary key
                ADOX.Index index = new ADOX.Index();
                index.PrimaryKey = true;
                index.Name = "PK_RecordsID";
                index.Columns.Append("RecordsID", table.Columns["RecordsID"].Type, table.Columns["RecordsID"].DefinedSize);
                table.Indexes.Append(index);
     
                MessageBox.Show("A new Data Table is successfully Created");
