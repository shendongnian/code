    catch (Exception ex)
    {
        string Detail = string.Empty;
        while ( ex != null ) 
        {
            if ( ex is Npgsql.NpgsqlException )
            {
                // safe check
                Npgsql.NpgsqlException ex_npg = (Npgsql.NpgsqlException)ex;
                Details = ex_npg.Detail;
            }
            // loop
            ex = ex.InnerException;
        }
        // warning, Detail could possibly still be empty!
        return Json(new { status = "Fail", detail = Detail });
    }
