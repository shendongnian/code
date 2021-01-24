    class Program
    {
        static void Main(string[] args)
        {
            XDocument gbConfig = XDocument.Parse(@"<TradingBlocConfiguration>
                                                 <GreatBritain xmlns=""GB"">
                                                   <Country/>
                                                   <Countries>
                                                      <Country/>
                                                      <Country/>                                                                        
                                                    </Countries>
                                                  </GreatBritain>                                                                     </TradingBlocConfiguration>");
            XDocument euConfig = XDocument.Parse(@"<TradingBlocConfiguration>
                                                 <EuropeanUnion xmlns=""EU"">
                                                   <Country/>
                                                   <Countries>
                                                      <Country/>
                                                      <Country/>                                                                        
                                                    </Countries>
                                                  </EuropeanUnion>                                                                     </TradingBlocConfiguration>");
            var greatBritainConfiguration = BuildConfig<TradingBlocConfiguration>(gbConfig);
            // A single 'Country' is always deserialized correctly..
            Console.WriteLine("Great Britain Country Type   " + greatBritainConfiguration.TradingBlocConfig.MemberCountry.GetType());
            // A List of 'Country' is deserialized to the wrong type, depending on what '[XmlElement]' tag is listed first.
            Console.WriteLine("Great Britain Countries Type " + greatBritainConfiguration.TradingBlocConfig.MemberCountries[0].GetType());
            var euConfiguration = BuildConfig<TradingBlocConfiguration>(euConfig);
            Console.WriteLine("EU Country Type              " + euConfiguration.TradingBlocConfig.MemberCountry.GetType());
            Console.WriteLine("EU Countries Type            " + euConfiguration.TradingBlocConfig.MemberCountries[0].GetType());
            Console.ReadLine();
        }
        private static T BuildConfig<T>(XDocument doc) where T : class
        {
            var stream = new MemoryStream();
            doc.Save(stream);
            T result;
            using (var reader = new StreamReader(stream))
            {
                stream.Position = 0;
                var xs = new XmlSerializer(typeof(T), new Type[] { typeof(GB.GreatBritain.Country) });
                result = (T)xs.Deserialize(reader);
            }
            return result;
        }
    }
    [XmlRoot("TradingBlocConfiguration")]
    public sealed class TradingBlocConfiguration
    {
        [XmlElement("GreatBritain", typeof(GB.GreatBritain), Namespace = "GB")]
        [XmlElement("EuropeanUnion", typeof(EU.EuropeanUnion), Namespace = "EU")]
        public TradingBloc TradingBlocConfig { get; set; }
    }
    [XmlRoot]
    [XmlInclude(typeof(GB.GreatBritain))]
    [XmlInclude(typeof(EU.EuropeanUnion))]
    public class BaseCountry { }
    public abstract class TradingBloc
    {
        [XmlIgnore]
        public abstract List<BaseCountry> MemberCountries { get; set; }
        [XmlIgnore]
        public abstract BaseCountry MemberCountry { get; set; }
    }
    namespace GB
    {
        [XmlRoot("GreatBritain")]
        public class GreatBritain : TradingBloc
        {
            [XmlElement("Country", typeof(Country))]
            public override BaseCountry MemberCountry { get; set; }
            [XmlArray("Countries")]
            [XmlArrayItem("Country", typeof(Country))]
            public override List<BaseCountry> MemberCountries { get; set; }
            [XmlRoot(Namespace = "GB")]
            public class Country : BaseCountry { }
        }
    }
    namespace EU
    {
        [XmlRoot("EuropeanUnion")]
        public class EuropeanUnion : TradingBloc
        {
            [XmlElement("Country", typeof(Country))]
            public override BaseCountry MemberCountry { get; set; }
            [XmlArray("Countries")]
            [XmlArrayItem("Country", typeof(Country))]
            public override List<BaseCountry> MemberCountries { get; set; }
            [XmlRoot(Namespace = "EU")]
            public class Country : BaseCountry { }
        }
    }
