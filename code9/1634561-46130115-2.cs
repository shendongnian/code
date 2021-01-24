    public static List<(Student Student, string SchoolName)> GetByType(string connString, int type)
    {
        using (mydb_DataContext db = new mydb_dbDataContext(connString))
        {
            return (from t1 in db.Students
                    where t1.type = type
                    select (t1, t1.School.Name)).ToList();
        }
    }
