    public class myMainModel
    {
      public xxxOverviewViewModel x {get;set;}
      public xxxOverviewViewModel y {get;set;}
    }
    
    myMainModel Get()
    { 
      ....
      return myMainModel.x;
    }
    
    myMainModel Get( int key)
    { 
      ....
      return myMainModel.y;
    }
