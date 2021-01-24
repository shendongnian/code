    /* setup schema and sample data */
                DataTable kit = new DataTable("Kits");
                kit.Columns.Add(new DataColumn("Kit ID"));
                kit.Columns.Add(new DataColumn("Sign Type"));
                kit.Columns.Add(new DataColumn("Sign Count", typeof(int)));
    
    
                DataTable signs = new DataTable("Signs");
                signs.Columns.Add(new DataColumn("Sign Type"));
                signs.Columns.Add(new DataColumn("Sign Weight", typeof(int)));
    
                DataRow rowBuffer = kit.NewRow();
    
                rowBuffer["Kit ID"] = "Kit 1";
                rowBuffer["Sign Type"] = "SVL-01";
                rowBuffer["Sign Count"] = 4;
    
                kit.Rows.Add(rowBuffer);
    
                rowBuffer = signs.NewRow();
    
                rowBuffer["Sign Type"] = "SVL-01";
                rowBuffer["Sign Weight"] = 44;
    
                signs.Rows.Add(rowBuffer);
    
                DataTable kitWeight = new DataTable();
                kitWeight.Columns.Add("Kit Type", typeof(string));
                kitWeight.Columns.Add("Kit Weight", typeof(int));
    
                /* join table and produce output set */
    
                var result = from dataRows1 in kit.AsEnumerable()
                             join dataRows2 in signs.AsEnumerable()
                             on dataRows1.Field<string>("Sign Type") equals dataRows2.Field<string>("Sign Type") into lj
                             from r in lj.DefaultIfEmpty()
                             select kitWeight.LoadDataRow(new object[]
                             {
                                dataRows1.Field<string>("Kit ID"),
                                dataRows1.Field<int>("Sign Count") * r.Field<int>("Sign Weight")
                              }, false);
    
                /* iterate through results - we could do the multiplication here or like we did in the LINQ up above */
                foreach (DataRow v in result)
                    Console.WriteLine(v["Kit Type"] + "\t" + v["Kit Weight"]);
