    public static class Extensions
    {
        public static void Update<T>(this T info, Action<T> action) where T : InfoClass
        {
            info.pull();
            action(info);
            info.push();
        }
    }
