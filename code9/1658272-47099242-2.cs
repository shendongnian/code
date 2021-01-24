    var ls = FindDerivedTypes(t.Assembly, typeof(HandlerMiddleware<>), typeof(IHttpHandler));
            System.Console.WriteLine(ls);
    public static List<System.Type> FindDerivedTypes(Assembly assembly
        , System.Type typeToSearch
        ,System.Type neededInterface)
    {
        List<System.Type> ls = new List<System.Type>();
        System.Type[] ta = assembly.GetTypes();
        int l = ta.Length;
        for (int i = 0; i < l; ++i)
        {
            if (ta[i].BaseType == null)
                continue;
            if (!ta[i].BaseType.IsGenericType)
                continue;
            
            // public class Middleman : IHttpHandler
            // public class HelloWorldHandler2 : HandlerMiddleware<Middleman>
            // public class HelloWorldHandler : HandlerMiddleware<HelloWorldHandler>, IHttpHandler
            var gt = ta[i].BaseType.GetGenericTypeDefinition();
            if (gt == null)
                continue;
            if (!object.ReferenceEquals(gt, typeToSearch))
                continue;
            Type[] typeParameters = ta[i].BaseType.GetGenericArguments();
            if (typeParameters == null || typeParameters.Length < 1)
                continue;
            if(neededInterface.IsAssignableFrom(typeParameters[0]))
                ls.Add(ta[i]);
        } // Next i 
        return ls;
    } // End Function FindDerivedTypes
