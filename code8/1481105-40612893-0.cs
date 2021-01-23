    public static DataTable ExecuteDynamicsStoredProc(string procedureName, SqlParameter[] args) {
        var dataTable = new DataTable();
    
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DynamicsDB"].ToString())) {
            using (var command = new SqlCommand(procedureName, connection)) { //use passed in proc name
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(args); //add all the parameters
                var dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
    
    public static void ExecuteProcOne(string name, int age, bool alive) {            
        SqlParameter p1 = new SqlParameter("name", name);
        SqlParameter p2 = new SqlParameter("age", age);
        SqlParameter p3 = new SqlParameter("alive", alive);
        
        var result = ExecuteDynamicsStoredProc("ExecuteProcOne", new SqlParameter[] { p1, p2, p3 });
    }
