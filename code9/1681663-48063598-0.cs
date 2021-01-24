    private async void button1_Click(object sender, EventArgs e)
    {
        var list = new List<MyClass>();
        using (var webClient = new System.Net.WebClient())
        {
            foreach (var url in this.textBox1.Lines)
            {
                var content = await webClient.DownloadStringTaskAsync(url);
                var myClass = Newtonsoft.Json.JsonConvert.DeserializeObject<MyClass>(content);
                list.Add(myClass);
            }
        }
        this.dataGridView1.DataSource = list;
    }
