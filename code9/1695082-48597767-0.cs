    var files = Directory.GetFiles(@"C:\Users\User\AppData\Roaming\.minecraft\versions\", "*.json");
    foreach (var filePath in files)
    {
        using (StreamReader file = File.OpenText(filePath))
        {
            JsonSerializer serializer = new JsonSerializer();
            VersionJsonRead MCVersionsList = (VersionJsonRead)serializer.Deserialize(file, typeof(VersionJsonRead));
            foreach (var item in MCVersionsList.id)
            {
                if (!Regex.IsMatch((string)MCVersionsList.id, "[a-z]"))
                {
                    versionsList.Items.Add((string)MCVersionsList.id);
                }
            }
        }
    }
