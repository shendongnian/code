    Exception exception = Server.GetLastError();
     string errorId = Guid.NewGuid().ToString();
        if (exception != null)
        {
            this.Application.Lock();
            this.Application[errorId] = exception;
            this.Application.Unlock();
            Server.ClearError();
            ExceptionManager.LogExceptionToTextFile(exception);
            ExceptionManager.LogExceptionToEmail(exception);
            if (!Response.IsRequestBeingRedirected)
                Response.Redirect("~/Error/Index?errorId="+errorId);
        }
