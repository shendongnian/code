    public class ApplicationDbContext: DbContext
	{
        public ApplicationDbContext()
        {
            while (!Debugger.IsAttached)
            {
                Thread.Sleep(100);
            }
        }
        ...
    }
