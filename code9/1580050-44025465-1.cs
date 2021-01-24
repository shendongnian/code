    class PowerfullPin
    {
        public string Id { get; set; }
    }
    
    class Test
    {
        public PowerfullPin PowerfullPin { get; set; }
    }
    
    class Main
    {
        Main()
        {
            Test Test = new Test();
            System.Diagnostics.Debug.WriteLine(Test.PowerfullPin?.Id);
        }
    }
