    string zip = "00000";
    bool isNull = string.IsNullOrEmpty(str);
    
    JObject jsonContent = new JObject(
                new JProperty("email_address", subscriber.Email),
                new JProperty("status", "subscribed"),
                new JProperty("state": "NY")
            );
    if(isNull) {
        jsonContent["ZIP"] = str;
    }
