    public void myMethod()
            {
                int a = 10;
                int b = 20;
                Action<int, int> multiplyDelegate;
                multiplyDelegate = Multiply;
                multiplyDelegate += Multiply2;
                multiplyDelegate(10, 20);
    
                Console.Read(); 
            }
    
            public void Multiply(int x, int y)
            {
                Console.WriteLine(x * 2);
            }
            public void Multiply2(int x, int y)
            {
                Console.WriteLine(x * y + 10);
            }
