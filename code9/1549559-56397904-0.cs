    namespace HangfireDemo.Core.Demo
    {
        public interface IDemoService
        {
            void RunDemoTask(PerformContext context);
        }
    
        public class DemoService : IDemoService
        {
            [DisplayName("Data Gathering Task <a href=\"jira.contoso.com\">Confluence Page</a>")]
            public void RunDemoTask(PerformContext context)
            {
                Console.WriteLine("This is a task that ran from the demo service.");
                BackgroundJob.ContinueJobWith(context.BackgroundJob.Id, () => NextJob());
            }
    
            public void NextJob()
            {
                Console.WriteLine("This is my next task.");
            }
        }
    }
