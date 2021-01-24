    using System;
    using System.Text;
    using System.Configuration;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices;
    public static async Task Run(string inputMessage, string inputBlob, TraceWriter log)
    {
        log.Info($"C# ServiceBus queue trigger function processed message: {inputMessage}");
        log.Info($"Blob:\n{inputBlob}");
        string deviceId = "Device10";
        var c2dmsg = new Microsoft.Azure.Devices.Message(Encoding.ASCII.GetBytes(inputMessage));
    
        // create proxy
        string connectionString = ConfigurationManager.AppSettings["myIoTHub2"];
        var client = ServiceClient.CreateFromConnectionString(connectionString);
        // send AMQP message
        await client.SendAsync(deviceId, c2dmsg);
        await client.CloseAsync();
    }
