    Test_SQLExceptionBubblesUp()
    {
        ExecuteSomethingThatCallsASproc(); //to check there is no exception
        MakeTheSprocFailWhenCalled();
        try 
        {
            ExecuteSomethingThatCallsASproc();
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
    }
    
    MakeTheSprocFailWhenCalled()
    {
         //insert a record into testSqlException table
    }
    
    UndoTheThingIDidInTheFirstLine()
    {
          //truncate testSqlException table 
    }
    
    in your SP:
    
    ALTER PROCEDURE [dbo].[mySqlExceptionPROC] 
    AS BEGIN 
        if (select count(*) from testSqlException) > 0
        begin 
            select 1 / 0 --divide by zero exception
        end 
        
        SELECT 'SP done'
    
    END
