    public static string GetTypeByID(int id)
    {
        using (ProjectTrackingEntities1 db = new ProjectTrackingEntities1())
        {
            //Here we apply a filter, the lambda here is what creates the WHERE clause
            var type = db.EmployeeTypes
                .SingleOrDefault(et => et.PK_EmployeeTypeID == id);
            if(type != null)
            {
                return type.EmployeeTypeName;
            }
            else
            {
                return "";
            }
        }
    }
