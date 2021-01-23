    public class Foo
    {
        readonly IBarFactory barFactory;
    
        public Foo(IBarFactory barFactory)
        {
            this.barFactory = barFactory;
        }
    
        public void Do()
        {
            var bar = this.barFactory.CreateBar();
            ...
        }
    }
    
    public interface IBarFactory
    {
        Bar CreateBar();
    }
