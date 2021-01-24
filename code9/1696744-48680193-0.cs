    public string ConvertReportToPDF(string fileName)
    {
        string resultFileName = "";
        key = "xxxxx";
    
        var requestContent = new MultipartFormDataContent();
        var fileStream = System.IO.File.OpenRead(fileName);
        var stream = new StreamContent(fileStream);
        requestContent.Add(stream, "File", fileStream.Name);
    
        var response = new HttpClient().PostAsync("https://v2.convertapi.com/docx/to/pdf?Secret=" + key, requestContent).Result;
        FileReportResponse responseDeserialized = JsonConvert.DeserializeObject<FileReportResponse>(response.Content.ReadAsStringAsync().Result);
    
        var path = SERVER_TEMP_PATH + "\\" + responseDeserialized.Files.First().FileName;
        System.IO.File.WriteAllText(path, Convert.FromBase64String(responseDeserialized.Files.First().FileData));
    
        return responseDeserialized.Files.First().FileName;
    }
