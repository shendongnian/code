    protected void Application_Start()
            {
                ....
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolEmployeesContext>());
           }
