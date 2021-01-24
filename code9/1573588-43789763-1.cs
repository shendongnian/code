    var readFields = dsReader.Select(r => {
        var serviceResponse = myService.Decrypt<DateTime>(r.GetString(DATE_VALUE), r.GetInt32(DEK_ID));
        if (serviceResponse.IsSuccessful)
            return new DataField<DateFieldValue> {
                FieldValue = new DateFieldValue { Data = serviceResponse.Value }
            };
        else
            return null;
    }).Where(df => df != null);
