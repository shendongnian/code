    IEnumerator Start()
    {
        //Run your Starting code
        startingCode();
    
        //Run Other coroutine functions
        yield return UploadPNG();
        yield return ConsoleMSG();
    }
    
    IEnumerator UploadPNG()
    {
    
    }
    
    IEnumerator ConsoleMSG()
    {
        yield return new WaitForSeconds(0f);
    }
    
    void startingCode()
    {
        //Yourstarting code
    }
