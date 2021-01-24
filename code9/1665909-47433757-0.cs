    public class MyFactory : IMyFactory<MyClient>
    {
        public MyClient Create ( string name )
        {
            var t = new MyClient();
            t.ClientName = name;
            return t;
        }
    }
