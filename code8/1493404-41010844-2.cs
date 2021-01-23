    private delegate void GenerateDelegate(string xmlContent);
    ///<summary>
    /// Call Infiniti GenerateWithData Web Service
    ///<summary>
    private void Generate(string xmlContent) 
    {
        Utils.IxGenerateWithData(payloadSettings.ProjectGUID, payloadSettings.DatasourceGUID, xmlContent, payloadSettings.InfinitiUsername, payloadSettings.InfinitiPassword, payloadSettings.ServiceWSDL);
    }
