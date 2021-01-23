        public static Func<string, string> Hello = name => "hello " + name;
        public static string Hello2(string name) => wrap(Hello)(name);
        // This does NOT retain the name of the arg for hints in the IDE 
        public static Func<string, string> Hello3 = name => wrap(Hello)(name);
        
        private static Func<string, T> wrap<T>(Func<string, T> orig)
        {
            return name => orig(name.ToUpper());
        } 
