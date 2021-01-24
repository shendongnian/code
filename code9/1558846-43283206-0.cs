    using System.Text.RegularExpressions;
    public static class StrExtensions
    {
        private static Regex csvSplit = 
            new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)", RegexOptions.Compiled);
        
        public static string[] FieldsFromCSV(this string str)
        {
            return csvSplit.Split(str);
        }
    }
