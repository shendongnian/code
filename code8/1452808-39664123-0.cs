    public class DateConverter : ConverterBase
        {
            public override object StringToField(string from)
            {
                //if you can't convert to date time.. .return null
                DateTime date;
                if (!DateTime.TryParse(from, out date))
                    return null;
    
                return date;
            }
    
            public override string FieldToString(object fieldValue)
            {
                return ((DateTime) fieldValue).ToString("MM-dd-yyyy").Replace(".", "");
            }
        }
