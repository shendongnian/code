    public class MyViewModel : PropertyChangedBase
    {
        Company company = new Company();
        List<string> countries = new List<string> { "USA", "Germany" };
        public string SelectedCountry
        {
            get { return company.country; }
            set
            {
                company.country = value;
                NotifyOfPropertyChange(() => SelectedCountry);
                NotifyOfPropertyChange(() => Cities);
            }
        }
        public List<string> Countries
        {
            get { return countries; }
            set
            {
                countries = value;
                NotifyOfPropertyChange(() => Countries);
                NotifyOfPropertyChange(() => Cities);
            }
        }
        public List<string> Cities
        {
            get
            {
                switch (company.country)
                {
                    case "USA": return new List<string> { "New York", "Los Angeles" };
                    case "Germany": return new List<string> { "Hamburg", "Berlin" };
                    default: return new List<string> { "DEFAULT", "DEFAULT" };
                }
            }
        }
    }
