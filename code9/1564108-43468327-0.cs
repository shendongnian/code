    private static DataTable geoFragenInstance;
    public static DataTable GeoFragenInstance
    {
       get 
       {
          if (geoFragenInstance == null)
          {
              geoFragenInstance = GEO_Fragen();
          } 
          return geoFragenInstance;
       }
    }
