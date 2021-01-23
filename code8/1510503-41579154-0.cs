    int sum = 0;
    
    var sw = Stopwatch.StartNew();
    for (int i = 0; i < Int32.MaxValue; i++) {
        bool condition = i < Int32.MaxValue / 2;
        sum += Convert.ToInt32(condition);
    }
    
                
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    
    sum = 0;
    sw = Stopwatch.StartNew();
    
    for (int i = 0; i < Int32.MaxValue; i++) {
        bool condition = i < Int32.MaxValue / 2;
        if (condition) {
            sum++;
        }
    }
    
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
