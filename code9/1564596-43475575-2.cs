        static void Main(string[] args)
        {
            string RegexDateIdentifier = @"\s+(?=\d{1,2}\/\d{1,2}\/\d{4})";
            var sqlComments = "07/04/2017 16:09:03 by Joe Bloggs) Added 07/04/2017 17:03:04 by Joe Bloggs) Updated";
            var comments = Regex.Split(sqlComments, RegexDateIdentifier);
            var list = comments.ToList();
            foreach (var s in list)
            {
                Console.WriteLine("|{0}|", s);
            }
        }
