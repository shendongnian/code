        DataTable table = new DataTable(); 
        var command = Properties.Settings.Default.Command;
        var connection = Properties.Settings.Default.Connection;
        using (var adapter = new SqlDataAdapter(command, connection))
            adapter.Fill(table)
        //Pass table to ReportForm
