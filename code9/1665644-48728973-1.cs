    using Microsoft.Extensions.Configuration;
    namespace GetUserIdAsyncNullExample
    {
        public interface ITest
        {
            void Method();
       
        }
        public class Test : ITest
        {
            public Test(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            private readonly IConfiguration Configuration;
            public void Method()
            {
                string here = Configuration["placeto:login"];
            }
        }
    }
