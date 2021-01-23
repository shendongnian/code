    var f = new ReportForm();
    DataTable table = new DataTable(); 
    var command = Properties.Settings.Default.Command;        /*SELECT Statement*/
    var connection = Properties.Settings.Default.Connection;  /*Connection String*/
    using (var adapter = new SqlDataAdapter(command, connection))
        adapter.Fill(table)
    f.ReportName = "Report1.rdlc" /*Or any other name*/
    f.ReportData = table;
    f.ShowDialog();
