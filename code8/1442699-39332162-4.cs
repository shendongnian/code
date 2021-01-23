     List<string> tableNames; // for table Names
     string columnName = "TestName"; // your ColumnName
            private void Form1_Load(object sender, EventArgs e)
            {
                SqlConnection cnn = new SqlConnection("Server=.;Database=dbName;Trusted_Connection=True;"); // connection string
                cnn.Open();
                tableNames = cnn.GetSchema("Tables").AsEnumerable().Select(x=> x[2].ToString()).ToList(); // get all table Names and put them into string List.
                SqlDataAdapter adp;
                DataTable dt;
                foreach (var item in tableNames) // loop in names
                {   dt =  new DataTable(); 
                    adp = new SqlDataAdapter("Select * from dbo.[" + item + "]", cnn);
                    adp.Fill(dt);
                    if (dt.Columns.Contains(columnName)) // check columnName in loop
                    {
                        TabPage tb = new TabPage(); //If we had a match then we need a tabpage
                        tb.Text = columnName; // Named with columnName
                        tabControl1.TabPages.Add(tb); // Add to TabControl
                        PutControls(tb); // Then call our method to add components
                    }
                }
            }
