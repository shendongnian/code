    public abstract class LockableJobBase
    {
        protected static object LockObject = new object();
    }
    public class ClickProfileJob : LockableJobBase, IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                lock (LockObject)
                {
                    using (StreamWriter sw = new StreamWriter(".\\visits_to_others.txt", true))
                    {
                        // your sw stuff
                    }
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
        }
    }
    public class ClickLikeJob : LockableJobBase, IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                lock (LockObject)
                {
                    using (StreamWriter sw = new StreamWriter(".\\visits_to_others.txt", true))
                    {
                        // your sw stuff
                    }
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
        }
    }
