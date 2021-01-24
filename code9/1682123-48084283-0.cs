    public void DebugBoxUpdate(string incomingString)
    {
        JArray array = JArray.Parse(incomingString);
        DebugBoxTest.Text = JsonConvert.SerializeObject(array, Formatting.Indented);
    }
