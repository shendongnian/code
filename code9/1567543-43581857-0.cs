        public static void Main(string args[])
        {
            List<object> objectList = new List<object>();
            var commandText = "Select name  from sys.tables";
            SqlConnection sqlConn = null;//Initialize
            SqlCommand command = new SqlCommand(commandText, sqlConn);
            var sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                commandText = $"Select * from {sqlReader["name"]}";
                command = new SqlCommand(commandText, sqlConn);
                var subReader = command.ExecuteReader();
                while (subReader.Read())
                {
                    //Loop through and add to list
                    objectList.Add();
                }
            }
        }
