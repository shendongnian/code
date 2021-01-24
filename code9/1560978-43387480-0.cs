    private void putValue(object value) 
        {
            if (value==null)
            {
                return;
            }
            if (value is IMwsObject)
            {
                parameterPrefix.Append('.');
                (value as IMwsObject).WriteFragmentTo(this);
                return;
            }
            string name = parameterPrefix.ToString();
            if (value is DateTime)
            {
                parameters.Add(name, MwsUtil.GetFormattedTimestamp((DateTime)value));
                return;
            }
            string valueStr = value.ToString();
            if (value is decimal)
            {
                valueStr = valueStr.Replace(",", ".");
            }
            if (valueStr==null || valueStr.Length==0) 
            {
                return;
            }
            if (value is bool)
            {
                 valueStr = valueStr.ToLower();
            }
            parameters.Add(name, valueStr);
        }
