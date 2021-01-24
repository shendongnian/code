    public class MyAction
    {
        //there could be several fields with data for Execute method.
        //Type of this fields should be serializable.
        public string DataForExecute { get; set; }
        public void Execute()
        {
            //Do all you need here...
        }
    }
