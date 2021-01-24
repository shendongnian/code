    public async void button1_Click(object sender, EventArgs e)
    {
        textbox.Text = await RunAsync();
    }
    static async Task<string> RunAsync() 
    {
        using (var client = new HttpClient())
        {
            var values = new Dictionary<string, string>
            {
                { "token", "aez" },
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("localhost", content);
            return await response.Content.ReadAsStringAsync();
        }
    }
