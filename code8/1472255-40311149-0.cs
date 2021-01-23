    public static string GetRouteName(this Route route)
    {
         if(route != null)
              return route.DataToken.GetRouteName();
    
         throw new Exception("Invalid Route.");
    }
