    public static void Download_File_Post(string extendURI, IEnumerable<KeyValuePair<string, string>> values)
    {
        //create post parameters
        var content = new FormUrlEncodedContent(values);
        var response = GlobalVar.client.PostAsync(GlobalVar.baseURI + extendURI, content).Result;
        Stream stream = response.Content.ReadAsStreamAsync().Result;
            using (FileStream file = new FileStream("testfile.xlsx", FileMode.Create, System.IO.FileAccess.Write))
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            file.Write(bytes, 0, bytes.Length);
            stream.Close();
        }
    }
