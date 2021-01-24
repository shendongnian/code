    using (TextWriter writer = new StreamWriter(csvLocaitonAndName))
            {
                var csvUpdate = new CsvWriter(writer);
                csvUpdate.Configuration.TypeConverterCache.AddConverter<DateTime?>(new DateConverter("yyyyMMdd"));
                csvUpdate.Configuration.HasHeaderRecord = false;
                csvUpdate.WriteRecords(list);
            }
    
    public class DateConverter : ITypeConverter
        {
            private readonly string _dateFormat;
    
            public DateConverter(string dateFormat)
            {
                _dateFormat = dateFormat;
            }
    
            public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    DateTime dt;
                    DateTime.TryParseExact(text, _dateFormat,
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.None,
                                           out dt);
                    if (IsValidSqlDateTime(dt))
                    {
                        return dt;
                    }
                    
                }
    
                return null;
            }
            public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            {
                return ObjectToDateString(value, _dateFormat);
            }
    
            public string ObjectToDateString(object o, string dateFormat)
            {
                if (o == null) return string.Empty;
    
                DateTime dt;
                if (DateTime.TryParse(o.ToString(), out dt))
                    return dt.ToString(dateFormat);
                else
                    return string.Empty; 
            }
            public bool IsValidSqlDateTime(DateTime? dateTime)
            {
                if (dateTime == null) return true;
    
                DateTime minValue = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());
                DateTime maxValue = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString());
    
                if (minValue > dateTime.Value || maxValue < dateTime.Value)
                    return false;
    
                return true;
            }
