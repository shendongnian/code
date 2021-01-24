    string feedcolumns = "select FeedColumnName from  myTable where FeedProcessID = @feedprocessid";
    DataTable dt = new DataTable("datafeed");
    using (SqlConnection connUpd = new SqlConnection("MyConnection")) {
        using (SqlCommand columnscommand = new SqlCommand(feedcolumns, connUpd)) {
            columnscommand.Parameters.AddWithValue("@feedprocessid", feedprocessid);
            connUpd.Open();
            var dataReader = columnscommand.ExecuteReader();
            dt.Load(dataReader);
        }
    }
