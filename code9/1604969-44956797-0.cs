    foreach (var uploadSpec in xDoc.Root.Elements("fileUploadSpecification"))
    {
        var newSettingsData = new SettingsData();
        newSettingsData.UploadBucket = uploadSpec.Element("UploadBucket").Value;
        newSettingsData.Region = uploadSpec.Element("Region").Value;
        newSettingsData.DirectoryPath = uploadSpec.Element("DirectoryPath").Value;
        var types = uploadSpec.Descendants("FileType").Elements("type").Select(e => e.Value);
        foreach (var type in types)
        {
            newSettingsData.FileType.Add(type);
        }
        //  Or if newSettingsData.FileType is List<String>...
        //newSettingsData.FileType.AddRange(types);
        dataList.Add(newSettingsData);
    }
