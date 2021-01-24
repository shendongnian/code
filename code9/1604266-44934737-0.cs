    // Set the DateFormatHandling wherever you are configuring JSON.Net.
    // This is usually globally configured per application.
    var settings = new JsonSerializerSettings
    {
        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
    };
    // When you serialize, DateTime and DateTimeOffset values will be in this format.
    string json = JsonConvert.SerializeObject(yourDateTimeValue, settings);
