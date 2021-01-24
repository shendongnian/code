    public class Executor
    {
        private List<Func<Task>> _actions;
        private Action<Exception> _catchAction;
        public Executor()
        {
            _actions = new List<Func<Task>>();
            _catchAction = exception => { };
        }
        public Executor With(Func<Task> action)
        {
            _actions.Add(action);
            return this;
        }
        public Executor CatchBy(Action<Exception> catchAction)
        {
            _catchAction = catchAction;
        }
        public async Task Run()
        {
            var tasks = _actions.Select(action => action());
            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                _catchAction()
            }            
        }
    }
