        public class CustomDbConfiguration : DbConfiguration
        {
            public CustomDbConfiguration()
            {
                this.AddInterceptor(new TemporalTableCommandTreeInterceptor());
            }
        }
        // from /a/40302086
        [DbConfigurationType(typeof(CustomDbConfiguration))]
        public partial class DataContext : System.Data.Entity.DbContext
        {
            public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
            {
                // other stuff or leave this blank
            }
        }
