        private static bool AssignHex4<T>(string hex, out T val)
        {
            Type t = typeof(T);
            MethodInfo mi = t.GetMethod("TryParse", new Type[] { typeof(string), typeof(NumberStyles), typeof(IFormatProvider), typeof(T).MakeByRefType()});
            if (mi != null)
            {
                object[] parameters = new object[] {hex, NumberStyles.AllowHexSpecifier, null, null};
                object result = mi.Invoke(null, parameters);
                if ((bool) result)
                {
                    val = (T)parameters[3];
                    return true;
                }
            }
            val = default(T);
            return false;
        }
