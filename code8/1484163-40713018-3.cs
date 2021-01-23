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
            this.Delay1(x=> {
                Console.WriteLine(x);
                this.Delay2(y => {
                    Console.WriteLine(y);
                    this.Delay3(z=> {
                        Console.WriteLine(z);
                        callback();
                    }); 
                });
            });
        }
    }
