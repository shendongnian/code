     private String GetValueFromQueryString(String value)
        {
            try
            {
                return Request.QueryString[value].ToString();
            }
            catch (System.Exception exp)
            {
                return String.Empty;
            }
        }
