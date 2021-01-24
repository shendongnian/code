     DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           
                table.Columns.Add("Dosage", typeof(int));
                table.Columns.Add("Drug", typeof(string));
                table.Columns.Add("Patient", typeof(string));
                table.Columns.Add("Date", typeof(DateTime));
                // Here we add five DataRows.
                table.Rows.Add(25, "Indocin", "David", DateTime.Now);
                table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
                table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
                table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
                table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
           
        }
       
        protected void ExportDataTableToCSV()
        {
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("content-disposition", "attachment;filename=UserDetails.csv");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sb.Append(table.Columns[i].ColumnName + ',');
            }
            sb.Append(Environment.NewLine);
            for (int j = 0; j < table.Rows.Count; j++)
            {
                for (int k = 0; k < table.Columns.Count; k++)
                {
                    sb.Append(table.Rows[j][k].ToString() + ',');
                }
                sb.Append(Environment.NewLine);
            }
            Response.Write(sb);
            Response.Flush();
            Response.End();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportDataTableToCSV();
        }
