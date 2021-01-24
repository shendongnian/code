    using (DashboardDBConDataContext db = new DashboardDBConDataContext(connectionString))
    {
         DBDashboard storedDashboard = (from t in db.Dashboards
                                        select t).FirstOrDefault();
         //Always check for null when selecting First() or FirstOrDefault()
         if(storedDashboard == null) {
            storedDashboard = new DBDashboard();
         }
     
         ms.Seek(0, SeekOrigin.Begin);
         storedDashboard.DashboardStream = new Binary(ms.ToArray());
         db.SubmitChanges();
    }
