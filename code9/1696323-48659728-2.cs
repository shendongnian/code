    SqlConnection sqlConn = new SqlConnection("server = ServerName; " + "Trusted_Connection = yes; " + "database = ReportPool; " + "connection timeout = 120");//Sql connection
    
                SqlCommand sqlCmd = new SqlCommand(String.Format("SELECT {0} FROM {1}",//SQl command
                    "Product, Price, Quantity",
                    "ReportPool.dbo.TestTable"
                    ), sqlConn);
    
    
    
    
                DataTable dataTable = new DataTable();//Created a new DataTable
    
                DataColumn dc = new DataColumn();//Made a new DataColumn to populate above DataTable
                dc.DataType = System.Type.GetType("System.String");//Defined the DataType inside, this can be [[int]] if you want.
                dc.ColumnName = "Product";//Gave it a name (important for the custom expression - can only be one word so use underscores if you need multiple words)
    
                DataColumn dc2 = new DataColumn();
                dc2.DataType = System.Type.GetType("System.Decimal");
                dc2.ColumnName = "Price";
    
                DataColumn dc3 = new DataColumn();
                dc3.DataType = System.Type.GetType("System.Decimal");
                dc3.ColumnName = "Quantity";
    
                DataColumn dc4 = new DataColumn();
                dc4.DataType = System.Type.GetType("System.Decimal");
                dc4.ColumnName = "CalculatedColumn";
                dc4.Expression = "Price * Quantity";//Multiplying the Price and Quantity DataColumns
    
                dataTable.Columns.Add(dc);//Add them to the DataTable
                dataTable.Columns.Add(dc2);
                dataTable.Columns.Add(dc3);
                dataTable.Columns.Add(dc4);
    
                dataGridControl.ItemsSource = dataTable.DefaultView;//Set the DataGrid ItemSource to this new generated DataTable
    
                sqlConn.Open();//Open the SQL connection
    
                SqlDataReader reader = sqlCmd.ExecuteReader();//Create a SqlDataReader
    
                while (reader.Read())//For each row that the SQL query returns do
                {
                    DataRow dr = dataTable.NewRow();//Create new DataRow to populate the DataTable (which is currently binded to the DataGrid)
                    dr[0] = reader[0];//Fill DataTable column 0 current row (Product) with reader[0] (Product from sql)
                    dr[1] = reader[1];
                    dr[2] = reader[2];
    
                    dataTable.Rows.Add(dr);//Add the new created DataRow to the DataTable
                }
     
