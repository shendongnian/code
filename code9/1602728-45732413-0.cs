        public static void ExportBuildDef(Microsoft.TeamFoundation.Build.Client.IBuildDefinition buildDefinition, string project, string filePath)
        {
            Console.WriteLine($"Exporting build definition '{buildDefinition.Name}' from '{project}' project.");
            var json = JsonConvert.SerializeObject(
                buildDefinition, 
                Newtonsoft.Json.Formatting.Indented, 
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            json = removePasswords(json);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Build definition '{buildDefinition.Name}' succesfully exported to '{filePath}'.");
        }
        private static string removePasswords(string json)
        {
            string res = json;
            var searchFor = "\"Password\":";
            var startIndex = json.IndexOf(searchFor);
            if (startIndex >= 0)
            {
                var endIndex = json.IndexOf(",", startIndex);
                var pwd = json.Substring(startIndex, endIndex - startIndex);
                if (pwd.IndexOf(":") > 0)
                {
                    pwd = json.Substring(startIndex, endIndex - startIndex).Split(':')[1].Trim();
                    res = json.Replace(pwd, "\"{hidden}\"");
                }
            }
            return res;
        }
