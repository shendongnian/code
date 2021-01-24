    public static Extensions
    {
        public void Update<T>(this T info, Action<T> action) where T : InfoClass
        {
            info.pull();
            action();
            info.push();
        }
    }
