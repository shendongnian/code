    public class Visitor
    {
        public long Id
        {
            get; set;
        }
        public string VisitorName
        {
            get; set;
        }
        public long CountryId
        {
            get; set;
        }
        public string CountryNameString
        {
            get 
            {
                var myCountry = //Add your code to look up the country name linked to the given 'CountryId' (value) and return the name
                return myCountry != null ? myCountry.CountryName : string.Empty;
            }
        }
    }
