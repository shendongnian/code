    public interface IDoStuff
    {
        Task DoSomethingAsync();
    }
    
    public class MyDoStuff : IDoStuff
    {
        public Task DoSomethingAsync()
        {
            ...
        }
    }
