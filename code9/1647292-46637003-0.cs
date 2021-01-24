    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Tuple<string, string>> userInputValues = new List<Tuple<string, string>>(); // obviously implement the correct user values here
            // This is the money below.
            // you'll have only valid ParamInfo objects here:
            List<ParamInfo> paramFactory = new ParamInfoFactory(userInputValues).ValidParameters;         
        }
    
        public class ParamInfo
        {
            public string Name { get; set; }
            public bool IsMandatory { get; set; }
            public bool IsRequired { get; set; }
            public bool IsOptional { get; set; }
            public bool IsForSorting { get; set; }
            public bool IsForPaging { get; set; }
            public Type ExpecteDataType { get; set; } // <--- you really don't need this.
            // where are you storing the item1.value?
            // are you storing it as a string, or as the proper type that it represents?
        }
        public class ParamInfoFactory
        {
            public List<ParamInfo> ValidParameters { get; set; }
            public ParamInfoFactory(List<Tuple<string, string>> userSuppliedValues)
            {
                ValidParameters = new List<ParamInfo>();
                foreach (Tuple<string, string> userValue in userSuppliedValues)
                {
                    if (UserInputValuesAreValid(userValue))
                    {
                        // all the values are valid. you can now create and add the parameters to your list.
                        // remember to instantiate it as you wish with the right values etc in there.
                        ValidParameters.Add(new ParamInfo());
                    }
                }
            }
            private bool UserInputValuesAreValid(Tuple<string, string> userValue)
            {
                return IsNameValid(userValue.Item1) && IsDataValid(userValue.Item2);
            }
            private bool IsDataValid(string data)
            {
                return IsValidDate(data) || IsValidNumber(data); // you can also implement the IsValidEnum or any other method you want
            }
            private static bool IsValidDate(string data)
            {
                DateTime dateValue;
                bool isDate = DateTime.TryParse(data, out dateValue);
                return isDate;
            }
            //private static bool IsEnum(string data)
            //{
            //    Colors colorValue;
            //    bool isEnum = Enum.TryParse(data, out colorValue);
            //    return isEnum;
            //}
            private static bool IsValidNumber(string data)
            {
                int number;
                bool isNumber = Int32.TryParse(data, out number);
                return isNumber;
            }
            private bool IsNameValid(string userInputName)
            {
                return SearchParameters.ParamList.Any(paramInfo => paramInfo.Name == userInputName.ToLower());
            }
            private static class SearchParameters
            {
                public static List<ParamInfo> ParamList = new List<ParamInfo>
                {
                    new ParamInfo {Name ="location", IsMandatory = true , ExpecteDataType = typeof(ulong) } ,
                    new ParamInfo {Name ="service", IsMandatory = true  , ExpecteDataType = typeof(ServiceType)} ,
                    new ParamInfo {Name ="start", IsMandatory = true  , ExpecteDataType = typeof(DateTimeOffset)} ,
                    new ParamInfo {Name ="appointmentType", IsMandatory = true  , ExpecteDataType = typeof(AppointmentType)} ,
                    new ParamInfo {Name ="status", IsOptional = true  , ExpecteDataType = typeof(string)} ,
                    new ParamInfo {Name ="end", IsOptional = true  , ExpecteDataType = typeof(DateTimeOffset)} ,
                    new ParamInfo {Name ="clinicianGender", IsOptional = true , ExpecteDataType = typeof(AdministrativeGender)}   ,
                    new ParamInfo {Name ="_sort", IsForSorting = true , ExpecteDataType = typeof(string)},
                    new ParamInfo {Name ="_count", IsForPaging = true , ExpecteDataType = typeof(uint)}
                };
            }
        }
    }
