    public ActionResult ProcessData(string processTimeStamp)
    {
        bool isComplete = false;
        bool isCancelComplete = false;
        string errMessage = "";
        try
        {
            // process 1 <-- this starts immediately. So you can't stop that.
            if( Convert.ToString(Session["CancelProcessTimestamp"]) != processTimeStamp)
            {
               // process 2
            }
            else
            {
               isCancelComplete = true;
            }
            // OTHER PROCESSES
            if(Convert.ToString(Session["CancelProcessTimestamp"]) != processTimeStamp)
            {
               // update to database
               isComplete = true; // only if it completes the last process
            }
            else
            {
               // you can undo the work done in process 1, 2 etc. 
               // Like deleting an uploaded file. Or if any primary key is returned from Process 1, then delete the corresponding entry in Data base
               isCancelComplete = true;
            }
        }
        catch (Exception e)
        {
            errMessage = e.Message;
        }
        return Json(new { IsComplete = isComplete, IsCancelComplete = isCancelComplete , ErrorMessage = errMessage });
    }
    public ActionResult CancelProcessData(string processTimeStamp)
    {
        Session["CancelProcessTimestamp"] = processTimeStamp;
        return Json(true);
    }
