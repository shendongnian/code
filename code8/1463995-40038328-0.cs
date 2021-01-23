    class TestComp1
    {
        private Timer _timer;
        public TestComp1()
        {
            _timer = new Timer(o => TestInt++,null,0,1000);
        }
    
        [ViewableProperty]
        public int TestInt { get; set; } = 0;
    }
