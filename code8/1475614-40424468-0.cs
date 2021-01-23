      public void CreateKeyspace()
        {
            cluster = Cluster.Builder().AddContactPoint("192.168.30.104").Build();
            session = cluster.Connect();//
            session.Execute("CREATE KEYSPACE acc_meter WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 3 };");
            
        }
