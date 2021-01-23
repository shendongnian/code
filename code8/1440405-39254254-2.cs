    public static class CarExt
    {
         public static void InstallFeature(this Car car, Feature feature) 
         {
             feature.Install(car);  
         }
    }
