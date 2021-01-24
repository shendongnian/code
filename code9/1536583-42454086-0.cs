     private DataGridView masterDataGridView = new DataGridView();
        private BindingSource masterBindingSource = new BindingSource();
        private DataGridView detailsDataGridView = new DataGridView();
        private BindingSource detailsBindingSource = new BindingSource();
    private void GetData()
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    "Integrated Security=SSPI;Persist Security Info=False;" +
                    "Initial Catalog=Northwind;Data Source=localhost";
                SqlConnection connection = new SqlConnection(connectionString);
    
                // Create a DataSet.
                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;
    
                // Add data from the Customers table to the DataSet.
                SqlDataAdapter masterDataAdapter = new
                    SqlDataAdapter("select * from Customers", connection);
                masterDataAdapter.Fill(data, "Customers");
    
                // Add data from the Orders table to the DataSet.
                SqlDataAdapter detailsDataAdapter = new
                    SqlDataAdapter("select * from Orders", connection);
                detailsDataAdapter.Fill(data, "Orders");
    
                // Establish a relationship between the two tables.
                DataRelation relation = new DataRelation("CustomersOrders",
                    data.Tables["Customers"].Columns["CustomerID"],
                    data.Tables["Orders"].Columns["CustomerID"]);
                data.Relations.Add(relation);
    
                // Bind the master data connector to the Customers table.
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "Customers";
    
                // Bind the details data connector to the master data connector,
                // using the DataRelation name to filter the information in the 
                // details table based on the current row in the master table. 
                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "CustomersOrders";
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
