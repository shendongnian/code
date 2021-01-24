    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Program starts"); //+++ Yes, in the console
            RealClassFromAbstract realClassFromAbstractObject = new RealClassFromAbstract();
            Task.Factory.StartNew(async () =>//CHANGE 1/5: async lambda
            {
                try
                {
                    //CHANGE 2/5: await
                    await realClassFromAbstractObject.MethodWithException();
                    Console.WriteLine("Nothing in the console, that's correct"); //--- Notihng in the console
                }
                catch (Exception exception)
                {
                    Console.WriteLine("2. Nice, exception! " + exception); //+++ Yes, in the console!
                }
            }).ConfigureAwait(false);
            
            Console.WriteLine("3. Program ends"); //+++ Yes, in the console
            Console.ReadKey();
        }
    }
    abstract class AbstractClass
    {
        //CHANGE 3/5: returned type is Task
        public abstract Task MethodWithException();
    }
    class RealClassFromAbstract : AbstractClass
    {
        //CHANGE 4/5: returned type is Task according to the abstact class
        public override async Task MethodWithException()
        {
            throw new Exception("This exception would be caught by outer try-catch block");
            
            
            //Anythig else, await....
            await Task.Delay(3);
            //CHANGE 5/5: await or:
            return;//or "Task.CompletedTask" in .NET >=4.6 if no awaits or Task.FromResult() in .NET <4.6
        }
    }
