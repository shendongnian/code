    public ConnectionCheckResult checkInternetAvailable()
    {
        int Desc;
        ConnectionCheckResult result = new ConnectionCheckResult();
    
        if (InternetGetConnectedState(out Desc, 0) == true)
        {
            try
            {
                dbConnection StartConn = new dbConnection();
                SqlConnection MyConnetion = StartConn.GetConnection();
    
                MyConnetion.Open();
    
                if (MyConnetion.State == ConnectionState.Open)
                {
                    result.Success = true;
                }
    
                MyConnetion.Close();
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "The database connection does not available, May be because of this reasons: \n\n1- there is a new version of the program available. \n2- database has some maintenance. \n\n Please check later :)";
            }
        }
        else
        {
            result.Success = false;
            result.Message = "No internet connection available , Please check later :) \nThanks.";
        }
    
        return result;
    }
