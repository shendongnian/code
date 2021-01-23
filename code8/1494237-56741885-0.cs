            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM MyTable";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
                 
            var dataTable = new DataTable();
            dataTable.Load(reader);
            List<MyObject> myObjects = new List<MyObject>();
            if (dataTable.Rows.Count > 0)
            {
                var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                // Here you get the object
                myObjects = (List<MyObject>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<MyObject>));
            }
           
            myConnection.Close();
