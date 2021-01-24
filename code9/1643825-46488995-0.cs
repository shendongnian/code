    public class Blagdani
    {
        public static List<Blagdani> Blagdani_lista;
        public DateTime datum { get; set; }
        public string dan_u_tjednu { get; set; }
        static Blagdani()
        {
            Blagdani_lista = new List<Blagdani>
            {
                new Blagdani {datum = new DateTime(2017, 08, 05), dan_u_tjednu = "Subota"},
                new Blagdani {datum = new DateTime(2017, 08, 15), dan_u_tjednu = "Utorak"},
                new Blagdani {datum = new DateTime(2017, 09, 29), dan_u_tjednu = "Petak"}
            };
        }
    }
