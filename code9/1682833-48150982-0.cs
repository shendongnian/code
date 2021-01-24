    public class MyConfiguration
    {
        // Static async Create function, does everything you'd normally do in the constructor:
        public static async Task<MyConfiguration> CreateAsync()
        {
            Dictionary<string,string> allParameters = await ServiceConfiguration.GetAllParameters(...);
            MyConfiguration createdConfiguration = new MyConfiguration(allParameters);
            return createdConfiguration;
         }
         // make sure that no one except CreateAsync can call the constructor:
         private MyConfiguration(Dictionary<string,string> allParameters)
         {
              parameters = allParameters;
         }
    }
