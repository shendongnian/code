    public abstract class AbstractProcess<T>
    {
        public abstract T DoProcess();
        public T Process()
        {
            //do your common tasks
            return DoProcess();
        }
    }
    public class Process1 : AbstractProcess<Process1>
    {
        public override Process1 DoProcess()
        {
            return new Process1();
        }
    }
    public class Process2 : AbstractProcess<Process2>
    {
        public override Process2 DoProcess()
        {
            return null;
        }
    }
