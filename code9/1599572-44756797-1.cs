    public class Credentials
    {
        private static readonly Lazy<Credentials> instanceHolder =
            new Lazy<Credentials>(() => new Credentials());
        public IReadOnlyDictionary<string, string> Passwords { get; private set; }
        public Credentials Instance { get { return instanceHolder.Value; } }
        private Credentials()
        {
            var channel = typeof(Credentials).Assembly
                .GetCustomAttributes<AssemblyChannelAttribute>()
                .ElementAt(0)
                .Type;
            switch (channel)
            {
                case ChannelType.Dev:
                    this.Passwords = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
                    {
                        ["User1"] = "Pwd1",
                        ["User2"] = "Pwd2",
                        // etc
                    });
                    break;
                case ChannelType.Beta:
                    // etc
                    break;
                case ChannelType.PreProd:
                    // etc
                    break;
                case ChannelType.Prod:
                    // etc
                    break;
            }
        }
    }
