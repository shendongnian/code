        public static MyEntities SelectDb(String DataBase,String sqlUser,String pw, String serverInstance){
            var selectedDbase = new MyEntities();
            // so only reference the changed properties
            // using the object parameters by name
            selectedDbase.ChangeDatabase
                (
                    initialCatalog: DataBase,
                    userId: sqlUser,
                    password: pw,
                    dataSource: serverInstance// could be ip address 100.23.45.67 etc
                );
            return selectedDbase;
        }
