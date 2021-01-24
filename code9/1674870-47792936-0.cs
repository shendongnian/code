    public class MyWebModule : NancyModule
    {
        public MyWebModule()
        {
            Get["/"] = _ => "Received GET request";
        }
    }
