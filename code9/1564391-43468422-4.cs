    public void MyMethod()  // method that could throw an exception
    {
       if (sqlex.Number == 5120)
       {
           throw new NoPermissionSqlException("You do not have permissions to attach this file.");
       }
    }
