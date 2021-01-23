    [DebuggerHidden]
    public void Update(INFITF.AnyObject objectToUpdate)
    {
        HandledException ex = new HandledException("Update Failed");
        bool updateSuccesful = false;
        try
        {
            Part.UpdateObject(objectToUpdate);
            updateSuccesful = true;
        }
        catch
        {
            throw ex;
        }
        finally
        {
            if (!updateSuccesful && !ex.Handled)
            {
                if(!Part.IsUpToDate(objectToUpdate))
                    Part.Inactivate(objectToUpdate);
            }
        }
    }
