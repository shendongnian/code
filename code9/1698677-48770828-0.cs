    using (var ds = new System.Data.DataSet("My Data"))
            {
                ds.Tables.Add("File0");
                ds.Tables.Add("File1");
                string[] line;
                using (var reader = new System.IO.StreamReader("FirstFile"))
                {                       
                    //first we get columns for table 0                    
                    foreach (string s in reader.ReadLine().Split('\t'))
                        ds.Tables["File0"].Columns.Add(s);
                    while ((line = reader.ReadLine().Split('\t')) != null)
                    {
                        //and now the rest of the data. 
                        var r = ds.Tables["File0"].NewRow();
                        for (int i = 0; i <= line.Length; i++)
                        {
                            r[i] = line[i];
                        }
                        ds.Tables["File0"].Rows.Add(r);
                    }                   
                }
                //we could probably do these in a loop or a second method,
                //but you may want subtle differences, so for now we just do it the same way 
                //for file1
                using (var reader2 = new System.IO.StreamReader("SecondFile"))
                {
                    foreach (string s in reader2.ReadLine().Split('\t'))
                        ds.Tables["File1"].Columns.Add(s);
                    while ((line = reader2.ReadLine().Split('\t')) != null)
                    {
                        //and now the rest of the data. 
                        var r = ds.Tables["File1"].NewRow();
                        for (int i = 0; i <= line.Length; i++)
                        {
                            r[i] = line[i];
                        }
                        ds.Tables["File1"].Rows.Add(r);
                    }
                }
                //you now have these in functioning datatables. Because we named columns, 
                //you can call them by name specifically, or by index, to replace in the first datatable. 
                string[] columnsToReplace = new string[] { "firstColumnName", "SecondColumnName", "ThirdColumnName" };
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //you didn't give a sign of any relation between the two tables
                    //so this is just by row, and assumes the row count is equivalent.
                    //This is also not advised. 
                    //if there is a key these sets of data share
                    //you should join on them instead. 
                    foreach(DataRow dr in ds.Tables[0].Rows[i].ItemArray)
                    {
                        dr[3] = ds.Tables[1].Rows[i][columnsToReplace[0]];
                        dr[6] = ds.Tables[1].Rows[i][columnsToReplace[1]];
                        dr[11] = ds.Tables[1].Rows[i][columnsToReplace[2]];
                    }
                }
                //ds.Tables[0] now has the output you want.  
                string output = String.Empty;
                foreach (var s in ds.Tables[0].Columns)
                   output = String.Concat(output, s ,"\t");
                output = String.Concat(output, Environment.NewLine); // columns ready, now the rows. 
                foreach (DataRow r in ds.Tables[0].Rows)
                   output = string.Concat(output, r.ItemArray.SelectMany(t => (t.ToString() + "\t")), Environment.NewLine);
                if(System.IO.File.Exists("MYPATH"))
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter("MYPATH")) //or a variable instead of string literal
                    {                  
                        file.Write(output);
                    }
            }
