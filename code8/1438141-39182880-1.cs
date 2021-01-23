    public partial class VM {
    
            public VM() {
                var eng = new Country() {Name = "England"};
                var l1 = new League() {Name = "Championship" };
                l1.Events.Add(new Event() {MatchName = "Another event" });
                var l2 = new League() { Name = "Premier League" };
                l2.Events.Add(new Event() { MatchName = "Foo" });
                l2.Events.Add(new Event() { MatchName = "Bar" });
                eng.Leagues.Add(l1);
                eng.Leagues.Add(l2);
                this.Countries.Add(eng);
                
            }
    
            private ObservableCollection<Country> _countries = new ObservableCollection<Country>();
    
            public ObservableCollection<Country> Countries {
                get { return _countries; }
            }
    
        }
