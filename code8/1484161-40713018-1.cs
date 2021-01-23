     class Content
    {
    
        public void Delay1(Action<string> callback)
        {
            //something which takes 5000ms
            callback("hello");
        }
        public void Delay2(Action<string> callback)
        {
            //something which takes 5000ms
            callback("hello");
        }
        public void Delay3(Action<string> callback)
        {
            //something which takes 5000ms
            callback("hello");
        }
        public void Print(Action callback)
        {
            new Content().Delay1(x=> {
                Console.WriteLine(x);
                new Content().Delay2(y => {
                    Console.WriteLine(y);
                    new Content().Delay3(z=> {
                        Console.WriteLine(z);
                    }); }); });
        }
    }
