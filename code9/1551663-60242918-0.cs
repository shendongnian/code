            using System.Data.Odbc;
            String connectionString = "Dsn=HP5ODBC;uid=system;pwd=manager";          
            OdbcConnection coon = new OdbcConnection();
            coon.ConnectionString = connectionString;
            coon.Open();
            MessageBox.Show(coon.State.ToString());
