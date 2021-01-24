    private void RunEveryTenFrames(Color32[] pixels, int width, int height)
    {
        //Prepare parameter to send to the ThreadPool
        Data data = new Data();
        data.pixels = pixels;
        data.width = width;
        data.height = height;
    
        ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractFile), data);
    }
    
    private void ExtractFile(object a)
    {
        //Retrive the parameters
        Data data = (Data)a;
    
        Perform super = new HeavyOperation();
        if (super != null)
        {
            Debug.Log("Result: " + super);
            ResultHandler.handle(super);
        }
    }
    
    public struct Data
    {
        public Color32[] pixels;
        public int width;
        public int height;
    }
