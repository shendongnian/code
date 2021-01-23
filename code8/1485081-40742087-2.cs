    private void button1_Click(object sender, EventArgs e)
    {
        string output = JsonConvert.SerializeObject(_data.ToList<Person>());
        System.IO.File.WriteAllText("json.json", output);
    }
