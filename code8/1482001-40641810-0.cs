        public static void Main(string[] args)
        {
            List<string> parameters = new List<string>();
            string k = "a";
            string l = null;
            AddParam("k", k, parameters);
            AddParam("l", l, parameters);
            string[] result = parameters.ToArray();
        }
        public static void AddParam(string paramName, string paramValue, List<string> parameters)
        {
            if (paramValue == null)
                return;
            parameters.Add(paramName + "=" + paramValue);
        }
