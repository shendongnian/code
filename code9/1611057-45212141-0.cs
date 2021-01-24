            static void Main(string[] args)
        {
            DataTable Item = new DataTable();
            OdbcConnection connection = new OdbcConnection("DSN=Navision Frank-Backup");
            connection.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter();
            adapter.SelectCommand = new OdbcCommand("select \"No.\", Location from Item where \"No.\" = 'AA0182'", connection);
            OdbcCommandBuilder builder = new OdbcCommandBuilder(adapter);
            builder.QuotePrefix = builder.QuoteSuffix = "\"";
            adapter.Fill(Item);
            Item.Rows[0].BeginEdit();
            Item.Rows[0]["Location"] = "TC";
            Item.Rows[0].EndEdit();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(Item);
            connection.Close();
        }
