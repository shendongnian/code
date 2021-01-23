    class MyClass
    {
        static Action CreateCounter()
        {
            int counter = 0;
            return () => {
                Show(counter);
                counter++;
            };
        }
    
        Action showAndIncrementCounter = CreateCounter();
    
        public ShowAndIncrementCounter()
        {
            showAndIncrementCounter();
        }
    }
