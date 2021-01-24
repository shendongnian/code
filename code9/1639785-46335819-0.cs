        DataTable sortedFileData;
        using (FileStream fs = new FileStream(selectedProject, FileMode.Open, FileAccess.Read))
        using (StreamReader sr = new StreamReader(fs))
        using (JsonTextReader reader = new JsonTextReader(sr))
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    // Load each object from the stream and do something with it
                    JObject obj = JObject.Load(reader);
                    System.Windows.MessageBox.Show((string)obj["Country"]);
                    sortedFileData = JsonConvert.DeserializeObject<DataTable>((string)obj["DataTable1"]);
                }
            }
        }
        string sorted = "Name ASC, Age ASC, Date ASC";
        if (sortedFileData != null) 
        {
            DataView dtView = new DataView(sortedFileData) {Sort = sorted};
        }
