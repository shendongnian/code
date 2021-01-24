    public class TestingLogHub : Hub
    {
        public static readonly Dictionary<string, TestInstance> Instances =
                           new Dictionary<string, TestInstance>();
         
        public void SetParameter(string value)
        {
            Instances[Context.ConnectionId].ContinueWith(value);
        }
        ...
    }
    public class TestInstance : IDisposable
    {
        public TestInstance(string basePath, IHubContext host, string connectionId)
        {...
        }
        public void ContinueWith(string value)
        {
            if (_nextAction == null)
            {
                FinishExecution();
            }
            else
            {
                try
                {
                    _nextAction(value);
                }
                catch (Exception exception)
                {
                    Error(exception.Message);
                    FinishExecution();
                }
            }
        }
        public void RequestParameterFor(Action<string> action, string parameter, string defaultValue = null)
        {
            _nextAction = action;
            _host.Clients.Client(_connectionId).requestParameter(parameter, defaultValue??GetRandomText());
        }
    }
