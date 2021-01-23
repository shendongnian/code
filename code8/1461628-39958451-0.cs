    public static REngine engine = null;
            public static REngine GetInitiazedREngine()
            {
                if (engine==null)
                {
                    REngine.SetEnvironmentVariables();
                    engine = REngine.GetInstance();
                    engine.Initialize();
                }
                return engine;
            }
    CallR(int item)
    {
       //Get the initialized R Engine                             
                    REngine initializedEngine=GetInitiazedREngine();
      //Perform R
                    initializedEngine.SetSymbol("data", item);
                    initializedEngine.Evaluate("data<-data*data");
    //engine.dispose
    //Cannot use engine.dispose as re initialization of engine then, is not possible 
    }
