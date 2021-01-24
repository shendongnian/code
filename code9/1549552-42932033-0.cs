    namespace AkkaTest
    {
        using Akka.Actor;
        using Akka.Configuration;
        class Program
        {
            static void Main(string[] args)
            {
                //Main config could be load different ways. This is placeholder
                var mainConfig = ConfigurationFactory.Default();
                var conString = GetConnectionString();
                var conStringConfig = ConfigurationFactory.ParseString(
                    $@"akka.persistence.journal.sqlite.connection-string        = ""{conString}""
                       akka.persistence.snapshot-store.sqlite.connection-string = ""{conString}""
                ");
                mainConfig = mainConfig.WithFallback(conStringConfig);
                var system = ActorSystem.Create("stackOverflow", mainConfig);
            }
            private static string GetConnectionString()
            {
                return "1";
            }
        }
    }
