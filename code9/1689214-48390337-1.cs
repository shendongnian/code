    public GenericRecord(string col1, string col2, string col3, string groupName)
    {
       float convertedVal1;
       if (float.TryParse(col1, out convertedVal1))
       {
          ConvertedCol1 = convertedVal1;
       }
    }
