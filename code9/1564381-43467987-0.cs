    for(int i = 0; i < 3; i++)
    {
        try {
            using (SqlConnection SqlCon = new SqlConnection(myParam.SqlConnectionString))
            {
                  // your code
            }
            Thread.Sleep(1000); // wait some time before retry
            break; // connection established, quit the loop
        }
        catch(Exception e) {
            // do nothing or log error
        }
    }
