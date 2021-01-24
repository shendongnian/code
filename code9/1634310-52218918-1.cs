    /// <summary>
    /// Convert UserDateTime({9/7/2018 8:37:20 AM}) to JSON datetime(1536309440373) format
    /// </summary>
    /// <param name="givenDateTime"></param>
    /// <returns></returns>
    public static string GetJSONFromUserDateTime(DateTime givenDateTime)
    {
        string jsonDateTime = string.Empty;
        if (givenDateTime != null)
        {
            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            jsonDateTime = JsonConvert.SerializeObject(givenDateTime, microsoftDateFormatSettings);
            jsonDateTime = jsonDateTime.Replace("\"\\/Date(", "").Replace(")\\/\"", "");
        }
        return jsonDateTime;
    }
    /// <summary>
    /// Convert JSON datetime(1536309440373) to user datetime({9/7/2018 8:37:20 AM})
    /// </summary>
    /// <param name="jsonDateTime"></param>
    /// <returns></returns>
    public static dynamic GetUserDateTimeFromJSON(string jsonDateTime)
    {
        dynamic userDateTime = null;
        if (!string.IsNullOrEmpty(jsonDateTime))
        {
            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            userDateTime = JsonConvert.DeserializeObject("\"\\/Date(" + jsonDateTime + ")\\/\"", microsoftDateFormatSettings);
        }
        return userDateTime;
    }
