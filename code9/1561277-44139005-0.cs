    namespace System.Reflection
    {
        public class Assembly2
        {
            public static System.Reflection.Assembly LoadFile(string path)
            {
                System.Reflection.Assembly ass = null;
                
    #if NET_CORE
                // Requires nuget - System.Runtime.Loader
                ass = System.Runtime.Loader.AssemblyLoadContext.Default
                       .LoadFromAssemblyPath(path);
    #else
                ass = System.Reflection. Assembly.LoadFile(path);
    #endif 
                // System.Type myType = ass.GetType("Custom.Thing.SampleClass");
                // object myInstance = Activator.CreateInstance(myType);
                return ass;
            }
        }
    }
