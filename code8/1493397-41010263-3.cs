    WebRequest request = WebRequest.Create("https://shares.ppe.datatransfer.microsoft.com/api/v1/data/shares/");
    request.Method = "GET";
    request.Headers.Add("Authorization", "Basic " +
    Convert.ToBase64String(
    Encoding.ASCII.GetBytes("userid:password")));
    request.ContentType = "application/json";
    WebResponse response = request.GetResponse();
    Stream dataStream = response.GetResponseStream();
    // Open the stream using a StreamReader for easy access.
    StreamReader reader = new StreamReader(dataStream);
    // Read the content.
    string responseFromServer = reader.ReadToEnd();
    JArray items = JArray.Parse(responseFromServer);
    Console.WriteLine($"{"Keys".PadRight(24)}Values");
    Console.WriteLine($"{"".PadRight(50, '-')}");
    foreach (JToken token in items)
    {
        Dictionary<string, string> dictionary = token.ToObject<Dictionary<string, string>>();
        int length = 28;
        foreach (var property in dictionary)
        {
            Console.WriteLine($"{property.Key.PadRight(length)}{property.Value}");
        }
        Console.WriteLine($"----------------------");
    }
            
