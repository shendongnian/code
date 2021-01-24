    public static class StringExtensions
    {
        public static string ToCSV(this object field, bool first)
        {
            if(field != null)
            {
                string retVal = field.ToString();
                retVal = retVal.Contains(",") || retVal.Contains("\"") || retVal.Contains("\r\n") 
                    ? "\"" + retVal + "\"" : retVal;
                retVal = first ? retVal : "," + retVal;
                return retVal;
            }
            else
            {
                return first ? "" : ",";
            }
        }
    }
    public class Format
    {
        public string CommaSeparatedObject(Type layoutType, object value, bool header)
        {
            bool first = true;
            string retVal = "";
            PropertyInfo[] props = layoutType.GetProperties();
            if (header)
            {
                foreach (PropertyInfo prop in props)
                {
                    retVal += prop.Name.ToCSV(first);
                    first = false;
                }
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    retVal += prop.GetValue(value).ToCSV(first);
                    first = false;
                }
            }
            return retVal;
        }
    }
    public class Write
    {
        public void WriteObject(IEnumerable<myClass> myObj)
        {
            StreamWriter sw = new StreamWriter(parameters.OutputFile, true, Encoding.ASCII, 16 * 1024);
            
            foreach(var item in myObj)
            {
                sw.WriteLine(new Format().CommaSeparatedObject(typeof(myClass), item, false)));
            }
        }
    }
