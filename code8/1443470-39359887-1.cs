    OdbcCommand cmdTest = new OdbcCommand();
    cmdTest.Connection = MyConnection;
    cmdTest.CommandText = "call test.test_procedure()";
    using (OdbcDataReader returnRead = cmdTest.ExecuteReader())
    {
        while (returnRead.Read())
        {
            string test1 = returnRead.GetString(0); //'testing variable 1'
            int test2 = returnRead.GetInt32(1); //3
            //Do something
        }
    }
