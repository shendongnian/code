    public interface IAction
    {
        object PerformAction();
    }
    public interface IAction<T> : IAction
    {
        new T PerformAction();
    }
    public class SomeAction : IAction<string>
    {
        object IAction.PerformAction()
        {
            return PerformAction();
        }
        public string PerformAction()
        {
            return "some action result value";
        }
    }
    public class OtherAction : IAction<int>
    {
        object IAction.PerformAction()
        {
            return PerformAction();
        }
        public int PerformAction()
        {
            return 100;
        }
    }
	
