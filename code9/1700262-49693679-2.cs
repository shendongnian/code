      public class SetupWebAPI
     {
        static string User;
        static string Password;
        static string Endpoint;
        static object Content;
               
        static SetupWebApiResponse apiResponse;
        
        public static SetupWebApiResponse GetResponseInStringFormat(string user, string password, string endpoint)
        {
            User = user;
            Password = password;
            Endpoint = endpoint;
            ExecuteResponse().Wait();
            return apiResponse;
        }
        private static async Task ExecuteResponse()
        {
            SetupWebAPIAsync.SetAPIAuthentication(User, Password);
            apiResponse = await SetupWebAPIAsync.GetResponseAsync(Endpoint);
        }
