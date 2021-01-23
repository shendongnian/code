    public class MainViewModel : ObservableObject
        {
            private List<SampleData> sampleList;
    
            public List<SampleData> SampleList
            {
                get { return sampleList; }
                set { Set(ref sampleList, value); }
            }
    
            private Country selectedItem;
    
            public Country SelectedItem
            {
                get { return selectedItem; }
                set { selectedItem = value; }
            }
    
            private ObservableCollection<Country> countries;
    
            public ObservableCollection<Country> CountriesList
            {
                get { return countries; }
                set { this.Set(ref countries, value); }
            }
    
            public MainViewModel()
            {
                CountriesList = new ObservableCollection<Country> { new Country { Id = 1, Name = "India" }, new Country { Id = 1, Name = "Australia" } };
    
                SampleList = new List<SampleData>
                {
                    new SampleData
                    {
                        Input = "shan", RowNum = 3, SelectedCountry = "India"
                    },
    
                    new SampleData
                    {
                        Input = "raj", RowNum = 1, SelectedCountry =  "India"
                    },
    
                    new SampleData
                    {
                        Input = "sfk", RowNum = 9,  SelectedCountry =  "India"
                    },
    
                    new SampleData
                    {
                        Input = "ShanSfk", RowNum = 7,  SelectedCountry =  "India"
                    }
                };
            }
        }
