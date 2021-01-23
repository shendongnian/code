    MakeTheSprocFailWhenCalled();
    try 
    {
        ExecuteSomethingThatCallsASproc();
        throw new Exception();
        Assert.Fail("Should never have made it here");
    }
    catch(Exception e)
    {
        Assert.AreEqual(typeof(SqlException), e.GetType());
    }
    finally
    {
        UndoTheThingIDidInTheFirstLine();
    }
