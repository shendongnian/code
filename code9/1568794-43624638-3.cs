    public static class Env
    {
    #if DEBUG
        public static readonly bool Debugging = true;
    #else
        public static readonly bool Debugging = false;
    #endif
    }
