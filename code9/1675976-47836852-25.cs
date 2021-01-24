    // init
    double[][] arr = new double[2000][];
    for (int i = 0; i < arr.Length; i++)            
        arr[i] = new double[2000];
    
    double v = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr[i].Length; j++)
        {
            arr[i][j] = v;
            v++;
        }
    }
    Stopwatch sw = Stopwatch.StartNew();
    var reducedArr = RemoveColumn(arr, 200);
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Restart();
    var reducedArr2 = FastRemoveColumn(arr, 200);    
    sw.Stop();        
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Restart();
    var reducedArr3 = MultiThreadRemoveColumn(arr, 200); 
    sw.Stop();     
    Console.WriteLine(sw.ElapsedMilliseconds);
    // Check the result
    for (int i = 0; i < reducedArr.Length; i++)
    {
        for (int j = 0; j < reducedArr[i].Length; j++)
        {
            if(reducedArr[i][j] != reducedArr2[i][j]) throw new Exception();
            if(reducedArr[i][j] != reducedArr3[i][j]) throw new Exception();   
        }
    }
