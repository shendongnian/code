    // Code behind
    protected void ExportTaxInfoToPDF(Object sender, EventArgs e)
    {
        ...
        var serializedTable = this.TaxTableData.Value; // get passed data
        // use either dedicated class with SerializableAttribute or Dictionary type
        // this example uses Dictionary for simple HTML markups
        var serializer = new JavaScriptSerializer();
        Dictionary<String, Object> dict = serializer.Deserialize<Dictionary<String, Object>>(serializedTable);
        var table = dict["html"].ToString();
        ...
    }
