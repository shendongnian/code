    public void TestMethod()
    {
        List<Asset<IController>> assets = new List<Asset<IController>>();
        //Populate assets list here
        foreach (Asset<IController> asset in assets)
        {
            asset.Controller.ControllerMethod();
            //Here we cannot cast to a specific type easily because we may not know them at runtime. 
            //With the generic, we can still make any appropriate calls and not know the specifics
        }
    }
