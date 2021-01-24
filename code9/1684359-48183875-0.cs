    static void Main(string[] args)
    {
        string input = "Type:Non-Fiction Murder Non ISBN:000000001 Kill", key = null, value = null;
        Dictionary<string, string> namedFields = new Dictionary<string, string>();
        List<string> anyField = new List<string>();
        Regex regex = new Regex("( )|(:)", RegexOptions.Compiled);
        foreach (string field in regex.Split(input))
        {
            switch (field)
            {
                case " ":
                    _AddParameter(ref key, ref value, namedFields, anyField);
                    break;
                case ":":
                    key = value;
                    break;
                default:
                    value = field;
                    break;
            }
        }
        _AddParameter(ref key, ref value, namedFields, anyField);
    }
    private static void _AddParameter(ref string key, ref string value, Dictionary<string, string> namedFields, List<string> anyField)
    {
        if (key != null)
        {
            namedFields.Add(key, value);
            key = null;
        }
        else if (value != null)
        {
            anyField.Add(value);
            value = null;
        }
    }
