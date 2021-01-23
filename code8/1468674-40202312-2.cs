    Console.WriteLine(DateTime.Now.Ticks);
            
    var currVal = DateTime.Now.Ticks;
    for (int i = 0; i < 10000; i++) {
        if (currVal != DateTime.Now.Ticks) {
            Console.WriteLine(currVal);
            currVal = DateTime.Now.Ticks;
        }
    }
