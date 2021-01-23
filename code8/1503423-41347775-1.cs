    private Cliniciel_WebRV_Entities CreateConnection()
        {
            //Code to figure out which db to connect to (based on the other connection. You should consider caching that too if it doesn't change very often)
            var nameOrConnectionString = FigureOutConnection();
            var db = new Cliniciel_WebRV_Entities(nameOrConnectionString);
            return db;
        }
