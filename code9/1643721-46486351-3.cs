    public partial class myPerson : Person
    {
        public myPerson(Person p)
        {
            _ID = p.Id;
            _Nachname = p.Nachname;
            _Name = p.Name;
            _Geschlecht = p.Geschlecht;
            _Bilder = p.Bilder;
        }
        private int _ID;
        private string _Nachname;
        private string _Name;
        private string _Geschlecht;
        private EntitySet<Bilder> _Bilder;
        // add properties
    }
