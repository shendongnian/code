    public partial class MainWindow : Window
        {
            public List<CountryCurrencyPair> CurrencyList { get; set; } 
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                CurrencyList = GetCountryList();
            }
    
            public List<CountryCurrencyPair> GetCountryList()
            {
                return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(c => new RegionInfo(c.LCID)).Distinct()
                .Select(r => new CountryCurrencyPair()
                {
                    Country = r.EnglishName,
                    Currency = r.CurrencyEnglishName
                }).ToList();
            }
        }
    
        public class CountryCurrencyPair
        {
           public string  Country {get;set;}
           public string Currency { get; set; }
        }
