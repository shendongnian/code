    // Initial Load the Datatable Structure
      private void Main_Load(object sender, EventArgs e)
        {
            dtTopSQL.Columns.Add("SQL_ID", typeof(string));
            dtTopSQL.Columns.Add("Count", typeof(Int16));
            dtTopSQL.Columns.Add("CurTime", typeof(DateTime));
            ugTopSQL.DataSource = dtCurTopSQL; // Bind the merged Datatable.
        }
