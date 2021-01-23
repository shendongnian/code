     string columnName = "TestName"; // your ColumnName
            private void Form1_Load(object sender, EventArgs e)
            {
                SqlConnection cnn = new SqlConnection("Server=.;Database=db;Trusted_Connection=True;"); // connection string
                cnn.Open();
                SqlDataAdapter adp;
                DataTable dt;
                string tableName = "tableNane";
                dt = new DataTable();
                adp = new SqlDataAdapter("Select * from " + tableName, cnn);
                adp.Fill(dt);
                if (dt.Columns.Contains(columnName)) 
                {
                    TabControl tbControl = new TabControl();
                    tbControl.Height = 100;
                    tbControl.Width = 200;
                    tbControl.Name = columnName;
                    this.Controls.Add(tbControl);
                    TabPage tb = new TabPage();
                    tb.Text = columnName;
                    tbControl.TabPages.Add(tb);
                    PutControls(tb); // the method defined at the top of the answer.
                }
    
    
            }
