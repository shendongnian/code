    try   
    {
        statement one;
        statement two;
        commit;
    }
    catch  
    {
         error message
         statement 1 Rollback();
         statement 2 Rollback();
    }
    finally
    {
         if (con.State == Con.Open)
              con.Close();
    }
