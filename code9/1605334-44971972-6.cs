    foreach(var task in tasks)
    {   
        try
        {
            var pair=await task;
            pair.conf.LastReport=pair.report;
        }
        catch(Exception exc)
        {
            //Make sure the error is logged
            Log.Error(exc);
            ErrorQueue.Enqueue(new ProcessingError(conf,ex);
        }
    }
    //Handle errors after the loop
