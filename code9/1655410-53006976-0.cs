    public sealed class MyBooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if(TryParseConvertBoolean(text, out bool result))
            {
                return result;
            }
            return null;
        }
        public static bool TryParseConvertBoolean(string value, out bool result)
        {
            result = false;
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                    return false;
                else
                {
                    var lower = value.ToLower();
                    if (lower == "no" || lower == "n")
                    {
                        result = false;
                        return true;
                    }
                    else if (lower == "yes" || lower == "y")
                    {
                        result = true;
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }
    }
