    public bool GetLotInfo(string SupplierCode, out stLotInfo lotInfo, out string errorMessage)
    {
        var succesful = false;
        lotInfo = null;
        errorMessage = null;
        try
        {
            lotInfo = ... //whatever you need to do
            succesful = true;
        }
        catch (MyExpectedException e) //Put here the specific exceptions you are expecting,
                                      //Try to avoid catching the all encomapssing Exception
        {
            errorMessage = e.Message;
        }
        finally
        {
            //any clean up you need to do.
        }
        return succesful;
    }
