    class MyClass: IDisposable
        {
            public static int instanceCount;
            public MyClass()
            {
                instanceCount++;
            }
    
            public void Dispose()
            {
                instanceCount--;
            }
        }
