    public void voidSender()
    {
        //Send forever
        while(true)
        {
            serialArduino.WriteLine("Test");
            Thread.Sleep(2000);
        }
    }
