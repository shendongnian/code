    try
        {
            myconn.Open();
            a = myCmd.ExecuteScalar().ToString();
            DateTime DateFromAccess = Convert.ToDateTime(a);
           TimeSpan difference = DateFromAccess.Subtract(DateTime.Now);
           if (difference.TotalHours > 24)
              //Your Code to Cancel Booking
           else
              //"Booking can not be cancelled now";
            return a;
        }
    catch(Exception){
        //Handle exception
    }
