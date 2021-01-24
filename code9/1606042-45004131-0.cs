            public AppSettingsFile(string filePath)
            {
                _filePath = filePath;
                try
                {
                    var content = FileSystemHelpers.ReadAllTextFromFile(_filePath);
                    var appSettings = JsonConvert.DeserializeObject<AppSettingsFile>(content);
                    IsEncrypted = appSettings.IsEncrypted;
                    Values = appSettings.Values;
                    ConnectionStrings = appSettings.ConnectionStrings;
                    Host = appSettings.Host;
                }
                catch
                {
                    Values = new Dictionary<string, string>();
                    ConnectionStrings = new Dictionary<string, string>();
                    IsEncrypted = true;
                }
            }
            public bool IsEncrypted { get; set; }
            public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
            public Dictionary<string, string> ConnectionStrings { get; set; } = new Dictionary<string, string>();
