    namespace Assets
    {
        public class Example
        {
            public Example GrabSomeFoodInTheFridge()
            {
                // some work
                return this;
            }
    
            public Example WatchTv()
            {
                // some work
                return this;
            }
    
            public Example EatFood()
            {
                // some work
                return this;
            }
        }
    
        public class Demo
        {
            public Demo()
            {
                var example = new Example();
    
                var instance = example
                    .GrabSomeFoodInTheFridge()
                    .EatFood()
                    .WatchTv();
            }
        }
    }
