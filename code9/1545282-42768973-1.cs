        static void Main(string[] args)
        {
            String returnedValue = Method1();
        }
        public static string Method1()
        {
            Console.Write("Vorname: ");
            string vorname = Convert.ToString(Console.ReadLine());
            Console.Write("Nachname: ");
            string nachname = Convert.ToString(Console.ReadLine());
            Console.Write("Adresse: ");
            string adresse = Convert.ToString(Console.ReadLine());
            string info = vorname + nachname + adresse;
            return (info);
        }
