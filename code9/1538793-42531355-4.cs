    public class CityListItems
    {
        public string Name { get; set; }
        public CityListItems(string n)
        {
            this.Name = n;
        }
        // just for completeness, if you really intend to use ComboBox or ListBox
        public override string ToString()
        {
            return this.Name;
        }
    }
