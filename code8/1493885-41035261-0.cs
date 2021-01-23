    public class Loader : MarshalByRefObject
        {
            object CallInternal(string dll, string typename, string method, object[] parameters)
            {
                Assembly a = Assembly.LoadFile(dll);
                object o = a.CreateInstance(typename);
                Type t = o.GetType();
                MethodInfo m = t.GetMethod(method);
                return m.Invoke(o, parameters);
            }
    
            public static object Call(AppDomain domain, string dll, string typename, string method, params object[] parameters)
            {
                Loader ld = (Loader)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(Loader).FullName);
                object result = ld.CallInternal(dll, typename, method, parameters);
                AppDomain.Unload(domain);
                return result;
            }
        }
