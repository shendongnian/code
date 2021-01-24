    private async void button1_Click(object sender, EventArgs e) {
        textBox1.Text = "calling Test()...\r\n";
        await DownloadPageAsync();
        // need to get from DownloadPageAsync here: result, reasonPhrase, headers, code 
        textBox1.AppendText("done Test()\r\n");
    }
    static async Task<string> DownloadPageAsync()
    {
        // ... Use HttpClient.
        using (HttpClient client = new HttpClient())
        {
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri("http://192.168.2.70/")))
                {
                    using (HttpContent content = response.Content)
                    {
                        // need these to return to Form for display
                        string result = await content.ReadAsStringAsync();
                        string reasonPhrase = response.ReasonPhrase;
                        HttpResponseHeaders headers = response.Headers;
                        HttpStatusCode code = response.StatusCode;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                // need to return ex.message for display.
            }
        }
    }
