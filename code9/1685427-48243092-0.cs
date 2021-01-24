        internal static object CallMethod(Type type, string method, string parameters)
        {
            MethodInfo m = type.GetMethod(method, BindingFlags.Static | BindingFlags.Public);
            ParameterInfo[] p = m.GetParameters();
            object[] param = new object[p.Count()];
            UInt16 i = 0;
            foreach (ParameterInfo pi in p)
            {
                string pattern = $"-{pi.Name}=\".*\"|-{pi.Name}=.*?\\s"; // -paramName=paramValue || -paramName="param Value"
                foreach (Match _m in Regex.Matches(parameters, pattern, RegexOptions.IgnoreCase))
                {
                    Type paramType = pi.ParameterType;
                    string value = _m.Value.Replace($"-{pi.Name}=", "").Replace("\"", "").Trim();
                    param[i] = Convert.ChangeType(value, pi.ParameterType);
                }
                i++;
            }
            return m.Invoke(null, param);
        }
