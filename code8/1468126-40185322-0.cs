    public class RestClientTest
    {
        public static async Task<string> Login()
        {
            try
            {
                var request = WebRequest.CreateHttp(path);
                request.Headers["Username"] = "xxxxxxxxx";
                request.Headers["Password"] = "xxxxxxxxxxx";
                request.ContentType = "application/json";
                request.Method = "POST";
                byte[] byteArray = new byte[] { 0x31, 0x32, 0x33, 0x34, 0x35 };
                using (Stream dataStream = await request.GetRequestStreamAsync())
                {
                    await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
                }
                var response = await request.GetResponseAsync().ConfigureAwait(false);
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string resp = await reader.ReadToEndAsync();
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
