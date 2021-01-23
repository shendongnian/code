    private async void button2_Click(object sender, EventArgs e)
    {
        using (var client = new HttpClient())
        {
            HttpResponseMessage request = await client.GetAsync("http://172.16.20.10/LED=on");
        }
    }
