    public static string Date(int c)
        {
            string a;
            OleDbConnection myconn = DBConn();
            string myQ = "SELECT DateTime FROM Booking WHERE movie_ID=" + c;
            OleDbCommand myCmd = new OleDbCommand(myQ, myconn);
            try
            {
                myconn.Open();
    
                a = myCmd.ExecuteScalar().ToString();
    
                var can_cancel = canCancel(a);
                return a;
    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myconn.Close();
            }
        }
