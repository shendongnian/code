    public class Schlagworte
    {
        public string Artikelnummer { get; set; }
        public string Produktname { get; set; }
        public string Kundenauftrag { get; set; }
        public string Fertigungsauftrag { get; set; }
        public string Seriennummer { get; set; }
        public string Kundennummer { get; set; }
        public string Kunde { get; set; }
        public string Endkunde { get; set; }
        public string Repair { get; set; }
        public string Repairartikelnummer { get; set; }
        public string Kommentar { get; set; }
        public string Musterbild { get; set; }
        public string ErstelltAm { get; set; }
    }
    
    public class RootObject
    {
        public string Schlagwortmaske { get; set; }
        public Schlagworte Schlagworte { get; set; }
    }
