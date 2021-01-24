    using System.Configuration;
    public Form1()
    {
        //Check if a connectionString already exists
        //To the first slot there is a system configuration so 1 = no custom connectionString
        if (ConfigurationManager.ConnectionStrings.Count == 1)
            {
                FormConn frmConn = new FormConn();
                frmConn.ShowDialog();
                try
                {
                    //Restart Form1 in the case connectionString has changed
                    Application.Restart();
                }
                catch(Exception ex)
                {
                     MessageBox.Show(ex.Message);
                }
            }
            //Associates the custom connectionString to the string I will use in the code for operations that are connected to the DB.
            StringSQL = ConfigurationManager.ConnectionStrings[1].ConnectionString;
    }
