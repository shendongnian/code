    private static async void SendDeviceToCloudMessagesAsync()
    {
     double avgWindSpeed = 10;
     Random rand = new Random();
     while (true)
     {
         double currentWindSpeed = avgWindSpeed + rand.NextDouble() * 4 - 2;
         var telemetryDataPoint = new
         {
             deviceId = "myFirstDevice",
             windSpeed = currentWindSpeed
         };
         var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
         var message = new Message(Encoding.ASCII.GetBytes(messageString));
         await deviceClient.SendEventAsync(message);
         Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);
         await Task.Delay(1000);
     }
    }
