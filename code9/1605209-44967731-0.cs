    public class ManageReportLockAttribute
        : FilterAttribute, IActionFilter
    {
        private static readonly object lockObj = new object();
        // ...    
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ...
            ReportLockInfo lockInfo = GetFromDatabase(reportId);
            if(lockInfo.IsInProcess)
              RedirectToInformationView();
            lock(lockObj)
            {
              // read anew just in case the lock was set in the meantime
              // A new context should be used.
              lockInfo = GetFromDatabase(reportId); 
              if(lockInfo.IsInProcess)
                RedirectToInformationView();
              lockInfo.IsInProcess = true;
              SaveToDatabase(lockInfo);
              ...
            }
        }
    
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
          ...
          lock(lockObj)
          {
            lockInfo = GetFromDatabase(reportId);
            if (lockInfo.IsInProcess) // check whether lock was released in the meantime
            {
              lockInfo.IsInProcess = false;
              SaveToDatabase(lockInfo);
            }
            ...
          }
        }
    }
