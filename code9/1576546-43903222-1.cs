        public bool MyStateProperty { get; set; }
        
        public void MyFirstMethod()
        {
            // your code here
        }
        public void MySecondMethod()
        {
            // your code here
        }
        public void ChangeProperty()
        {
            // change value of state property - allow invoke other method after click
            MyStateProperty = !MyStateProperty;
        }
