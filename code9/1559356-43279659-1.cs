    public interface INotifModel
    {
        string Data { get; set; }
    }
    public interface INotif<out T> where T : INotifModel
    {
        T Model { get; }
    }
    public interface INotifProcessor<in T> where T : INotif<INotifModel>
    {
        void Yell(T notif);
    }
    public class HelloWorldModel : INotifModel
    {
        public string Data { get; set; }
        public HelloWorldModel()
        {
            Data = "Hello world!";
        }
    }
    public class HelloWorldNotif : INotif<HelloWorldModel>
    {
        public HelloWorldModel Model { get; set; }
        public HelloWorldNotif()
        {
            Model = new HelloWorldModel();
        }
    }
    public class HelloWorldProcessor<T> : INotifProcessor<T> where T : INotif<INotifModel>
    {
        public void Yell(T notif)
        {
            throw new NotImplementedException();
        }
    }
    public class HelloWorldProcessor : INotifProcessor<HelloWorldNotif>
    {
        public void Yell(HelloWorldNotif notif)
        {
            throw new NotImplementedException();
        }
    }
