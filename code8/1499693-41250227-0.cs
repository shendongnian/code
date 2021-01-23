    public static class Factory
    {
        //store constructors for type T
        static Dictionary<string, ConstructorInfo> ctors=new Dictionary<string, ConstructorInfo>();
        public static T New<T>(params object[] args)
        {
            var arg_types=args.Select((obj) => obj.GetType());
            var arg_types_names=args.Select((obj) => obj.GetType().Name);
            string key=string.Format("{0}({1})", typeof(T).Name, string.Join(",", arg_types_names);
            if(!ctors.ContainsKey(key))
            {
                // if constructor not found yet, assign it
                var ctor=typeof(T).GetConstructor(arg_types.ToArray());
                if(ctor==null)
                {
                    throw new MissingMethodException("Could not find appropriate constructor");
                }
                ctors[key]=ctor;
            }
            // invoke constructor to create a new T
            return (T)ctors[key].Invoke(args);
        }                
    }
