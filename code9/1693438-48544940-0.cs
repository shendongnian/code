    void Main()
    {
        CollectionHandler.origFileList.Add("Value 1");
        CollectionHandler.origFileList.Add("Value 2");
        CollectionHandler.origFileList.RemoveAt(1);
        CollectionHandler.origFileList.RemoveAt(0);
        //Output> origFileList - Is now empty
        CollectionHandler.origFileList.Add("Test Value #1 - Should not fire the callback !!! But it does");
        //Output> origFileList - Is now empty
        CollectionHandler.origFileList.Add("Test Value #2 - Should not fire the callback --- And it doesn't");
    }
    public static class CollectionHandler
    {
        private static List<string> _origFileList = new List<string>();
        public static List<string> origFileList
        {
            get
            {
                myTestCallback(_origFileList);
                if (_origFileList.Count < 1)
                {
                    //Fire a Callback Function Call Here
                    myTestCallback(_origFileList.Count());
                }
                return _origFileList;
            }
            set
            {
                _origFileList = value;
            }
        }
    
        private static void myTestCallback(object s)
        {
            Console.WriteLine(s.ToString());
            Console.WriteLine("========");
    
        }
    
        private static void myTestCallback(List<string> s)
        {
            foreach (var str in s)
                Console.WriteLine(str);
            Console.WriteLine("========");
        }
    }
