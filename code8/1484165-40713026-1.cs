        public class Content
        {
    
            public async void Delay1()
            {
                await Task.Delay(5000);
                Console.WriteLine("hello");
            }
            public async void Delay2()
            {
                await Task.Delay(5000);
                Console.WriteLine("hello");
            }
            public async void Delay3()
            {
                await Task.Delay(5000);
                Console.WriteLine("hello");
            }
            public void Print()
            {
                Delay1();
                Delay2();
                Delay3();
            }
        }
