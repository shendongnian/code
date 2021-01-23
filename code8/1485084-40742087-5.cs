    private void button1_Click(object sender, EventArgs e)
    {
        string output = JsonConvert.SerializeObject(_data);
        System.IO.File.WriteAllText("json.json", output);
    }
