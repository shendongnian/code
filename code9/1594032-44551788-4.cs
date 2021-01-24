     public partial class Payment : UserControl
        {
            public Payment()
            {
                InitializeComponent();           
            }
    
            private void DataGrid_Loaded(object sender, RoutedEventArgs e)
            {
                // ... Create a List of objects.
                var Countries = new List<Country>();
                Countries.Add(new Country(1,"India"));
                Countries.Add(new Country(2, "USA"));
                Countries.Add(new Country(3, "Italy"));
    
                var Visitors = new List<Visitor>();
                Visitors.Add(new Visitor(1, "John Smiler",2));
                Visitors.Add(new Visitor(2, "Don Boscoi",3));
                Visitors.Add(new Visitor(3, "Smith Son",1));
    
    
                var GridList = from p in Countries
                            from r in Visitors
                               where r.CountryID == p.CountryID
                            select new { r.VisitorName, p.CountryName };
    
                // ... Assign ItemsSource of DataGrid.
                var grid = sender as DataGrid;
                grid.ItemsSource = GridList;
            }
        }
        public class Country
        {
            public int CountryID { get; set; }
            public string CountryName { get; set; }
    
            public Country(int countryid, string countryname )
            {
                this.CountryID = countryid;
                this.CountryName = countryname;
            }
        }
        public class Visitor
        {
            public int VisitorID { get; set; }
            public string VisitorName { get; set; }
            public int CountryID { get; set; }
            public Visitor(int visitorid, string visitorname, int countryid)
            {
                this.VisitorID = visitorid;
                this.VisitorName = visitorname;
                this.CountryID = countryid;
            }
        }        
     }
