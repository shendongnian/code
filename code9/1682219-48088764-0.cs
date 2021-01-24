    @{
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        var jsonModel = serializer.Serialize(Model.Result);
    }
