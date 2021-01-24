    public class ApiLogger
    {
        ...
        public string OnActionException(Exception ex)
        {
            ...
            if (this._configuration.MailSupportOnException)
                RunInTask(...);
            ...
        }
        public virtual Task RunInTask(Action action)
        {
            return Task.Run(action);
        }
    }
