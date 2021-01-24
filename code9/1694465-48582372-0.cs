        static void Main(string[] args)
        {
            Guid g = DoParse<Guid>("33531071-c52b-48f5-b0e4-ea3c554b8d23");
            
        }
        public static T DoParse<T>(string value) 
        {
            T result = default(T);
            MethodInfo methodInfo = typeof(T).GetMethod("Parse");
            if (methodInfo != null)
            {
                
                ParameterInfo[] parameters = methodInfo.GetParameters();
                object classInstance = Activator.CreateInstance(typeof(T), null);
                object[] parametersArray = new object[] { value };
                result = (T)methodInfo.Invoke(methodInfo, parametersArray);
                
            }
            return result;
        }
