    public static List<Student> GetByType(string connString, int type)
    {
        using (mydb_DataContext db = new mydb_dbDataContext(connString))
        {
            db.DeferredLoadingEnabled = false;
            return (from t1 in db.Students
                    where t1.type = type
                    select t1).ToList();
        }
    }
