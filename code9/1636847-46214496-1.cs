    var formData = new List<FormField>();
    formData.Add(new FormField { FieldName = "Date", FieldValue = "2017-09-14" });
    formData.Add(new FormField { FieldName = "Name", FieldValue = "Job blogs" });
    formData.Add(new FormField { FieldName = "IsEnabled", FieldValue = "true" });
    // Initialize a new instance of the model
    MyViewmodel model = new MyViewmodel();
    // Get its property info
    PropertyInfo[] properties = model.GetType().GetProperties();
    // Loop through your form field data
    foreach(var field in formData)
    {
        // Get the matching property name
        PropertyInfo pi = properties.FirstOrDefault(x => x.Name == field.FieldName);
        if (pi == null)
        {
            continue;
        }
        // Convert the value to match the property type
        object value = Convert.ChangeType(field.FieldValue, pi.PropertyType);
        // Set the value of the property
        pi.SetValue(model, value);
    }
