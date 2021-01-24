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
    }
