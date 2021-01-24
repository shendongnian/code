    public class Program
    {
        public static void Main(string[] args)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(CountryData));
            var subReq = new CountryData();
            subReq.Countries.Add(new Country
            {
                CountryName = "name",
                Countrycode = "code",
                PercentOfBusiness = "12",
                AverageBusiness = "123",
                SalesMade = "120012"
            });
            subReq.Countries.Add(new Country
            {
                CountryName = "name2",
                Countrycode = "code2",
                PercentOfBusiness = "34",
                AverageBusiness = "345",
                SalesMade = "453453543"
            });
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString();
                }
            }
        }
    }
