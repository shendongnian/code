    public class MyEventProvider : IEventProvider
    {
        public event EventHandler<string> StringAvailable;
            
        public void RequestString()
        {
            var temp = StringAvailable;
            if (temp != null) temp(this, "aaaaa");
        }
    }
----
    var p = new MyEventProvider();
    var str = await p.RequestStringAsync();
