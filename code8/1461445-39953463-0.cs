    [WebMethod]
    public static string GetSelection(string selectedItem)
    {
    
        var json = new JavaScriptSerializer();
        var data = json.Deserialize<Dictionary<string, Dictionary<string, string>>[]>(selectedItem.ToString());
        var jsonObj = json.Serialize("proceeded");
        return jsonObj;
    }
