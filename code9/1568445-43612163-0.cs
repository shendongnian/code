    public class WorkPoint<T> where T : IModel
    {
        public static Func<T, T> Do { get; set; }
        public static Func<T, T> ReadyToWork{ get; set; }
        public WorkPoint(ModelUserFirst mod)
        {
           Do = m => UserFirstWorker.Instance().Do(m);
           ReadyToWork= m => UserFirstWorker.Instance().ReadyToWork(m);
        }
    }
