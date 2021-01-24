    BlockingCollection<Bitmap> cameraImages = new BlockingCollection<Bitmap>();
    
    if (processImageThread== null || !processImageThread.IsAlive)
    {
        processImageThread= new Thread(ProcessLoop);
        processImageThread.Name = "ProcessLoop";
        processImageThread.IsBackground = true;
        processImageThread.Start();
        Console.TraceInformation("ProcessLoop started");
    }
    
    private void ProcessLoop()
    {
        try
        {
            foreach (img in cameraImages.GetConsumingEnumerable(CancelProcessing.Token))
            {
                // Do your stuff               
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("ProcessLoop OperationCanceledException.");
        }
        finally
        {
    
        }
    }
