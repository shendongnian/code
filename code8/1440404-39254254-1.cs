    public static class CarExt
    {
         public static void InstallFeature(this Car car, IFeature feature) 
         {
             feature.Install(car);  
         }
    }
