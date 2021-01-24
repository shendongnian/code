     public static bool IsNetworkConnected ()
       {
          bool retVal = false;
        try {
            retVal = CrossConnectivity.Current.IsConnected;
            return retVal;
        } catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine (ex.Message);
            throw ex;
        }
    }
