    public void fillDataGrid()
        {
            try
            {
                using(OracleConnection connection = new OracleConnection("connectstring"))
                using(OracleCommand cmd = new OracleCommand("select * from my super table", connection ))
                {
                    connection .Open();
                    using(OracleDataReader oracleDataReader = cmd.ExecuteReader())
                    {
                         DataTable dataTable = new DataTable();
                         dataTable.Load(oracleDataReader );
                         myDataGrid.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     }
