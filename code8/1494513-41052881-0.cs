    bool success = false;
    string message = "Something went wrong";
    string rawData = "[{\"id\":\"0\",\"value\":\"1234\"}]";  // Broken
    object jsonData = JsonConvert.DeserializeObject<dynamic>(rawData);
    dynamic finalData = new { success = success, message = message, data = jsonData };
    
    JsonResult output = new JsonResult
    {
        Data = finalData,
        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
        MaxJsonLength = int.MaxValue
    };
    return output;
