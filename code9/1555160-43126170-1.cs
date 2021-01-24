    public class EF6CodeConfig : DbConfiguration
    {
        public EF6CodeConfig()
        {
            this.AddInterceptor(new EFCommandInterceptor());
        }
    }
