    public class GebruikerModel
    {
        public String Gebruikersnaam { get; set; }
        public String Wachtwoord { get; set; }
    
        // Om automapper automatisch te laten converteren simpelweg klassenaam (FaculteitModel) + property (Naam) gebruiken
        public String FaculteitModelNaam { get; set; }
        public String InstellingModelMNaam { get; set; }
    
    }
    
        public class FaculteitModel
        {
            public String Naam { get; set; }
        }                                                                                     
        
        public class InstellingModel
        {
            public String naam { get; set; }
        }
