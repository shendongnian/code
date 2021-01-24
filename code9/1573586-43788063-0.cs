    var readFields = from r in dsReader
        let serviceResponse = myService.Decrypt<DateTime>(r.GetString(DATE_VALUE), r.GetInt32(DEK_ID))
        where serviceResponse.IsSuccessful
        select new DataField<DateFieldValue>
        {
            FieldValue = new DateFieldValue { Data = serviceResponse.Value }
        };
