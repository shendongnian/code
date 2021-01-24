    var errors = new List<string>();
    var data = JsonConvert.DeserializeObject<CustomerData>(jsonString,
        new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
             {
                 errors.Add(earg.ErrorContext.Member.ToString());
                 earg.ErrorContext.Handled = true;
             }
        });
