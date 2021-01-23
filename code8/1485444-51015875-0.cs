        public static void SendMessage(LogLevel logLevel, string message)
        {
            if (!IsEnabled())
                return;
            
            //http://stackoverflow.com/a/15524271/647728
            ApplicationContext.Current.ApiClient.PostAsync<LogRequestModel, object>("/api/remote/receiver/log", new LogRequestModel { MacAddress = MacAddress, Text = message }).ContinueWith(t => { }, TaskContinuationOptions.OnlyOnFaulted);
            
        }
}
