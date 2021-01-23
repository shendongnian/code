        public class MyJob : IJob
        {
	        public void Execute(IJobExecutionContext context)
	        {
		        try
                {
                    // connect to internet or whatever.....
                }
                catch(Exception)
                {
                    throw new JobExecutionException(true);
                }
	        }
        }
