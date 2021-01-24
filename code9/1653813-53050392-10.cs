    public class MyHub : Hub
    {
        private readonly IDoStuff _doStuff;
        public MyHub(IDoStuff doStuff)
        {
            _doStuff = doStuff;
        }
        public string GetData()
        {
           return  _doStuff.GetData();
        }
    }
