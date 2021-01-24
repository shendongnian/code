    public class GebruikerFormulier : CSVClass
    {
        public int GebruikerFormulierId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Geboortedatum { get; set; }
        public string Straat { get; set; }
        public string Email { get; set; }
        public int Telnr { get; set; }
        public string Campus { get; set; }
        public string Richting { get; set; }
        public override string ToString()
        {
            return GebruikerFormulierId.ToString() + "," +
                                AsString(Voornaam) + "," +
                                AsString(Achternaam) + "," +
                                AsString(Geboortedatum) + "," +
                                AsString(Straat) + "," +
                                AsString(Email) + "," +
                                Telnr + "," +
                                AsString(Campus) + "," +
                                AsString(Richting) + Environment.NewLine;
        }
    }
