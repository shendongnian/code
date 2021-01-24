    namespace firstnamespacetest
    {
        class Program
        {
            static void Main(string[] args)
            {
                test t = new test();
    
                Console.WriteLine(t.BlockName);
                // prints "Old value"
    
                // event handler changes value
                t.TextBoxHandler();
    
                //prints new value
                Console.WriteLine(t.BlockName);
    
                Console.ReadLine();
            }
        }
    }
    namespace secondNameSpace
    {
        class test
        {
            private string _blockName;
    
            public string BlockName
            {
                get { return _blockName; }
                set { _blockName = value; }
            }
    
            public test()
            {
                // set initial value of blockname
                _blockName = "Old value";
            }
    
            public void TextBoxHandler()
            {
                _blockName = "New value of block";
            }
        }
    }
