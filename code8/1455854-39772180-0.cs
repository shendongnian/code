    IEnumerable<DataRow> enrichment = null;
    var dataTable = new DataTable();
    using (ReconContext context = new ReconContext())
    {
        string sql = "SELECT * FROM " + DestinationTable + "  WHERE LoadId =" + ExternalLoadId;
        using (SqlDataAdapter adapater = new SqlDataAdapter(sql, context.Database.Connection.ConnectionString))
        {
            adapater.Fill(dataTable);
        }
    }
    enrichment = dataTable.AsEnumerable();
    return enrichment;
