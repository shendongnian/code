    class Program
    {
        static void Main(string[] args)
        {
            var obj = new createGenericClass<IBaseService>();
            obj.CallDoSomeThing(new Web_Service(), 1, 2); // works well
            obj.CallDoSomeThingElse(new Voice_Service(), 3, 4); // works well
        }
    }
