    public static class RebusConfigEx
    {
        public static void UseCustomJsonSerialization(this StandardConfigurer<ISerializer> configurer)
        {
            configurer.Register(c => new YourCustomJsonSerializer());
        }
    }
