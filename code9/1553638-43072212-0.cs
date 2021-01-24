    public IEnumerable<ModsecurityLogEntry> ReadAuditLog()
    {
        var path = "C:\\inetpub\\logs\\modsec_audit.log";
    
        var list = new List<ModsecurityLogEntry>();
		
        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                var serializer = new JsonSerializer();
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    jsonTextReader.SupportMultipleContent = true;
    
                    while (jsonTextReader.Read())
                    {
                        JObject obj = JObject.Load(jsonTextReader);
                        var logEntry = JsonConvert.DeserializeObject<ModsecurityLogEntry>(obj.ToString());
                        list.Add(logEntry);
                    }
                }
            }
        }
		
        return list;
		
    }
