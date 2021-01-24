    public class Test
    {
        [Command]
        [CommandAlias("Method1Alias")]
        public void Method1()
        {
            System.Console.WriteLine("Method1");
        }
	
        [Command]
        [CommandAlias("Method2Alias")]
        public void Method2()
        {
            System.Console.WriteLine("Method2");
        }
        public void NonInvokableMethod()
        {
            System.Console.WriteLine("NonInvokableMethod");
        }
        public object Invoke(string cmd)
        {
            var type = GetType();
            var methodinfo = type.GetMethods().SingleOrDefault(x =>
                x.GetCustomAttribute(typeof(CommandAttribute)) != null //Only allow methods with the Command attribute
                &&
                (
                    x.Name == cmd //Match method name
                    || x.GetCustomAttributes(typeof(CommandAliasAttribute)) //Match alias
                        .Select(attr => attr as CommandAliasAttribute) //type cast to CommandAlias
                        .Any(attr => attr.Alias == cmd)
                ));
                if (methodinfo == null)
                    throw new InvalidOperationException($"No method named or aliased \"{cmd}\" was found.");
                var ret = methodinfo.Invoke(this, new object[0]);
                return ret;
        }
    }
