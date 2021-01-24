                my_rpt objRpt;
                // Creating object of our report.
                objRpt = new my_rpt();
                DataSet ds = new DataSet("MyDataSet");
                DataTable dt = new DataTable("MyDataTable");
                ds.Tables.Add(dt);
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("firstname", typeof(string));
                dt.Columns.Add("lastname", typeof(string));
                dt.Rows.Add(new object[] { 1,"John", "Smith"});
                dt.Rows.Add(new object[] { 2, "Mary", "Jones" });
                dt.Rows.Add(new object[] { 3, "Harry", "James" });
                // Setting data source of our report object
                objRpt.SetDataSource(ds);
                CrystalDecisions.CrystalReports.Engine.TextObject root;
                root = (CrystalDecisions.CrystalReports.Engine.TextObject)
                     objRpt.ReportDefinition.ReportObjects["txt_header"];
                root.Text = "Sample Report By Using Data Table!!";
                // Binding the crystalReportViewer with our report object. 
                crystalReportViewer1.ReportSource = objRpt;
