    var Cameras = new Dictionary<string, Process>()
    
         for (int i = 1; i <= cameraQuantity; i++)
                {
                    Process takepic;
                    //Process takepic+cameranumber;
                    takepic = new Process();
                    Cameras.Add("takepic"+cameranumber, takepic);
