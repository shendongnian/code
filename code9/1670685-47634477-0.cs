    public class Car : BindableBase
            {
                private string _Name;
                public string Name
                {
                    get { return _Name; }
                    set { Set(ref _Name, value); }
                }
    
                private string _Brand;
                public string Brand
                {
                    get { return _Brand; }
                    set { Set(ref _Brand, value); }
                }
    
                private bool _Electric;
                [XmlIgnore] //<----This!           
                public bool Electric
                {
                    get { return _Electric; }
                    set { Set(ref _Electric, value); }
                }
                
                private double _Price;
                public double Price
                {
                    get { return _Price; }
                    set { Set(ref _Price, value); }
                }            
            }
