    public bool GetLotInfo(string supplierCode, out StLotInfo lotInfo, out string errorMessage)
    {
        try
        {
            lotInfo = ... //whatever you need to do
            errorMessage = null;
            return true;
        }
        catch (MyExpectedException e) //Put here the specific exceptions you are expecting,
                                      //Try to avoid catching the all encomapssing System.Exception
        {
            errorMessage = e.Message;
            lotInfo = null;
            return false;
        }
        finally
        {
            //any clean up you need to do.
        }
        return succesful;
    }
