    using System.Web.Extensions;
    public string SerializeClassToJSON(object baseClass)
    {
        var jSerializer = new JavascriptSerializer();
        var jsonString = jSerializer.Serialize(baseClass);
        return jsonString;
    }
