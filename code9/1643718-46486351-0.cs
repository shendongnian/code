    public partial class myPerson : Person
    {
        public myPerson(Person p)
        {
            _ID = p.Id;
            _Nachname = p.Nachname;
            _Name = p.Name;
            _Bilder = p.Bilder;
            Name = name;
        }
        private int _ID;
        private string _Nachname;
        private string _Name;
        private string _Geschlecht;
        private EntitySet<Bilder> _Bilder;
        // add properties
    }
