    [TestMethod()] 
    public void GetUsersTest() 
    { 
        string connectionString = GetConnectionString();     
    
        using (TransactionScope ts = new TransactionScope()) 
        { 
            using (SqlConnection connection = 
                new SqlConnection(connectionString)) 
            { 
                connection.Open(); 
                DataLayer dataAccessLayer = new DataLayer();     
    
                DataSet dataSet = dataAccessLayer.GetUsers(); 
                AddNewUser("Fred", connection);     
    
                dataSet = dataAccessLayer.GetUsers(); 
                DataRow[] dr = dataSet.Tables[0].Select("[UserName] = 'Fred'"); 
                Assert.AreEqual(1, dr.Length); 
            } 
        } 
    }
