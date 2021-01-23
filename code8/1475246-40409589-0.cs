     public static async Task<string> Run(string input, TraceWriter log, string blobOutput)
        {
            log.Info($"C# manually triggered function called with input: {input}");
            await Task.Delay(1);
        
            blobOutput = input;
            return blobOutput;
        }
