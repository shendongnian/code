    [DbConfigurationType(typeof(MyDBConfiguration))]
    public partial class MyDbContext // : DbContext
    {
        public MyDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        { }
    }
    public class MyDBConfiguration : DbConfiguration {
        public MyDBConfiguration() {
            this.AddInterceptor(new MyCommandInterceptor());
        }
    }
