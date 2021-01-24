    var connStr = System
        .Configuration
        .ConfigurationManager
        .ConnectionStrings["ElectricsOnline"]
        .ConnectionString;
    using (var connection = new SqlConnection(connStr)) {
        ...
    }
