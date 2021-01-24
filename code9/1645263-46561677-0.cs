    static void Worker(int ix, byte[] array)
    {
        // you must write something back, note, I changed your Worker
        // function to static!
        array[ix] += 1uy;
    }
    
    void Run()
    {
        var gpu = Gpu.Default;
        var hostArray = new byte[100];
        // set your host array
        var deviceArray = gpu.Allocate<byte>(100); 
        // deviceArray is of type byte[], but deviceArray.Length = 0, 
        assert deviceArray.Length == 0
        assert Gpu.ArrayGetLength(deviceArray) == 100
        Gpu.Copy(hostArray, deviceArray);
        var testCnt = 10;
        gpu.For(0, testCnt, ix => Worker(ix, deviceArray));
        // you must copy memory back
        Gpu.Copy(deviceArray, hostArray);
        // check your result in hostArray
        Gpu.Free(deviceArray);
    }
