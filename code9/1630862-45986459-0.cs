    class Owner
    {
        class  AsHelper<T>
        {
            public static Func<Owner, T> As;
        }
        
        static Owner()
        {
            AsHelper<double>.As = _ => _.AsDouble;
            // Other implementations
        }
        public T As<T>() where T: struct
        {
            if(AsHelper<T>.As != null)
            {
                return AsHelper<T>.As(this);
            }
            else
            {
                // Default implementation or exception
                return default(T);
            }
        }
    }
