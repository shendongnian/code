    public ActionResult ProcessData(string processTimeStamp)
    {
        bool isComplete = false;
        bool isCancelComplete = false;
        string errMessage = "";
        try
        {
            // process 1 <-- this starts immediately. So you can't stop that.
            if( Convert.ToString(Session["CancelProcessTimestamp"]) == processTimeStamp)
            {
               // process 2
            }
            else
            {
               // you can undo the work done in process 1. Like deleting an uploaded file
               isCancelComplete = true;
            }
            if(Convert.ToString(Session["CancelProcessTimestamp"]) == processTimeStamp)
            {
               // update to database
               isComplete = true; // only if it completes the last process
            }
            else
            {
               // you can undo the work done in process 1 and 2. Like deleting an uploaded file
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
