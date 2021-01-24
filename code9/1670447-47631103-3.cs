    PI caseInfos = null;
    try
    {
        string strasd = response.Content.ReadAsStringAsync().Result;
        m_Logging.Log(SharedLib.LoggingMode.Prompt, "ReadAsStringAsync() result:{0}", strasd);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(PI));
        using (TextReader reader = new StringReader(strasd))
            caseInfos = (PI)serializer.Deserialize(reader);
        m_Logging.Log(SharedLib.LoggingMode.Prompt, "Deserializing caseInfos model succeeded...");
    }
    catch (Exception ex)
    {
        m_Logging.Log(SharedLib.LoggingMode.Error, "creating model failed, EXP:{0}", ex);
    }
