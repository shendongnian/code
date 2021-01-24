    using Oracle.DataAccess.Client;
    ...
    catch( Exception ex ) when ( (ex.InnerException as OracleException)?.Number == 1000 )
    {
        // stuff
    }
