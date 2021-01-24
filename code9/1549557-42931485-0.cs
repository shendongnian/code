    JArray jaVIP = new JArray();
    foreach (Detection v in listVIP)
    {
        jaVIP.Add(new JObject(
            new JProperty("Dateiname", v.m_sFilename),
            new JProperty("Objekt-ID", v.m_sObjectID),
            new JProperty("Unterordner", v.m_sSubfolder),
            new JProperty("Url-Download", v.m_sDownloadlink)));
    }
    JArray jaDFX = new JArray();
    foreach (Detection d in listDXF)
    {
        jaDFX.Add(new JObject(
            new JProperty("Dateiname", d.m_sFilename),
            new JProperty("Objekt-ID", d.m_sObjectID),
            new JProperty("Unterordner", d.m_sSubfolder),
            new JProperty("Url-Download", d.m_sDownloadlink)));
    }
    JObject j = new JObject(
        new JProperty("dxfFiles", jaDFX),
        new JProperty("vipFile", jaVIP));
    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + 
                      "\\test.json", j.ToString());
