    catch (SqlException ex)
    {
    	string sqlError = null;
    	for (int i = 0; i < ex.Errors.Count; i++)
    	{
    		sqlError += "Error Message " + ex.Errors[i].Message + "\n" + "Stored Procedure " +  ex.Errors[i].Procedure + " \n " + "Line Number " + ex.Errors[i].LineNumber;
    	}
    	LogTools.WriteLog("Sql Server error " + sqlError);
    	Variables.InstallStatusDetail = "Database connection failed";
    
    	if (!sqlError.Contains("connection to SQL Server"))
    	{
    		if (Variables.WriteToDatabase) 
    		{ 
    			try {
                    //I am assuming this is where you are trying to write the error back into the database
    				HostedDataBase.InsertRunStatusIntoInstallStatus('E', sqlError, null); 
    			} catch {
    				//ignore errors here
    			}
    		}
    	}
    }
