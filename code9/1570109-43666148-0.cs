    public class Example
    {
        public int Execute(int Param){ return Param + 1; }
    }
    public static ThreadSafeWrapper
    {
        public static int ExecuteSafe(object Instance, Func<int, int> Function, int Param)
        {
            lock(Instance)
                return Function(Param);
        }
    }
