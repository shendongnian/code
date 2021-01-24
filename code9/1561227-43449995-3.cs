    public interface IFake
    {
        Action GetFakeAction(Action action);
    }
    public class FakeSchedule : Schedule, IFake
    {
        public bool TransactionStarted { get; set; }
        public Action GetFakeAction(Action action)
        {
            return () => TransactionStarted = true;
        }
    }
