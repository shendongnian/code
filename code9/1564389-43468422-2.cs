    try
    {
       MyMethod();   
    }
    catch(NoPermissionSqlException ex)
    {       
       // ... handle no permission error here
       dostuff();
    }
    catch(Exception ex)
    {
       // ... default handler
    }
