    class Program
    {
        static void Main(string[] args)
        {
            List<Location> locations = new List<Location>();
            string foo = "/Hanoi/a2.3b6.7c8.4/Tphcm/n7.2a5.2";
            var bo = foo.Remove(0, 1).Split('/'); // split data by '/'
            // even bo elenment is address and odd element has specific data like number and letter
            for (int i = 0; i < bo.Length; i = i + 2)
            {
                var str = bo[i]; // Address
                var str1 = bo[i + 1]; // Letter and Number
                var arrLetters = str1.Where(c => char.IsLetter(c)).ToArray(); // Get Letters
                for (int j = 0; j < arrLetters.Length; j++)
                {
                    string splittedLetter = string.Empty; 
                    string number = string.Empty;
                    
                    if (j+1 != arrLetters.Length)
                    {
                        splittedLetter = str1.Split(arrLetters[j + 1])[0]; 
                        number = Regex.Replace(splittedLetter, "[A-Za-z ]", "");
                        str1 = str1.Replace(splittedLetter, string.Empty);
                    }
                    else
                    {
                        number = Regex.Replace(str1, "[A-Za-z ]", "");
                    }
                    // add to list, db or where you want :)
                    locations.Add(new Location
                    {
                        Address = str,
                        Letter = arrLetters[j].ToString(),
                        Number = number
                    });
                }
            }
            Console.ReadKey();
        }
    }
    class Location
    {
        public string Address { get; set; }
        public string Letter { get; set; }
        public string Number { get; set; }
    }
