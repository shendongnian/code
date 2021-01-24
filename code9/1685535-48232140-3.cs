    public class Thrower
    {
        public static TRet Throw<TException, TRet>(string message) where TException : Exception
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message);
        }
        public int MyMethod()
        {
            if (new Random().Next() == 2)
            {
                return 42;
            }
            return Throw<Exception, int>("Test");
            // I would have to put "return -1;" or anything like that here for the code to compile.
        }
    }
