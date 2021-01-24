    try
        {
            //Creating DB Context
            var con = ConfigurationManager.ConnectionStrings["teststring"].ConnectionString;
            TestDataContext db = new TestDataContext(con);
            //Querying database. This should cause an exception to be thrown!?
            var rows =  from s in db.Table
                        orderby s.Id descending
                        select s; 
            //Returning the View with the data
            return View(rows);
        }
        catch (SqlException ex)
        {
            ErrorInfo err = new ErrorInfo("Something went wrong when trying to query the database. See the log for details.");
            err.WriteToErrorLog(ex);
            return View("Error", err);
        }
