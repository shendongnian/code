    ...
        try
        {
            ...
            Dts.TaskResult = (int)ScriptResults.Success;
         }
        catch (Exception ex)
       {
            Dts.Events.FireError(0, "ERROR", ex.Message, null, 0);
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
    }
