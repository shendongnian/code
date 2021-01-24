    private async void button1_Click(object sender, EventArgs e) {
        textBox1.Text = "calling Test()...\r\n";
        var result = await DownloadPageAsync();
        // need to get from DownloadPageAsync here: result, reasonPhrase, headers, code 
        textBox1.AppendText("done Test()\r\n");
    }
    static HttpClient client = new HttpClient();
    static async Task<DownloadPageAsyncResult> DownloadPageAsync() {
        // ... Use HttpClient.
        var result = new DownloadPageAsyncResult();
        try {
            using (HttpResponseMessage response = await client.GetAsync(new Uri("http://192.168.2.70/"))) {
                using (HttpContent content = response.Content) {
                    // need these to return to Form for display
                    string resultString = await content.ReadAsStringAsync();
                    string reasonPhrase = response.ReasonPhrase;
                    HttpResponseHeaders headers = response.Headers;
                    HttpStatusCode code = response.StatusCode;
                    
                    
                    result.result = resultString;
                    result.reasonPhrase = reasonPhrase;
                    result.headers = headers;
                    result.code = code;
                }
            }
        } catch (Exception ex) {
            // need to return ex.message for display.
            result.errorMessage = ex.Message;
        }
        return result;
    }
