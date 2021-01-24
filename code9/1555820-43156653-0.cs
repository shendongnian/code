    public abstract class ServiceBase<TArgs>
    {
        public abstract int StandardMethod(TArgs args);
    }
    
    public class Arguments
    {
         public string Text { get; set; }
         public int Number { get; set; }
    }
    
    public class ServiceForB : ServiceBase<Arguments>
    {
        public override int StandardMethod(Arguments arguments)
        {
            // Thanks to generics, arguments are strongly-typed and
            // and you can access its properties as usual!
            string text = arguments.Text;
            int number = arguments.Number;
    
            return 0;
        }
    }
