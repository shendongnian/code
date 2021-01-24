    static void Main(string[] args)
        {
            var myList = new List<string>
            {
                "a2michelle",
                "michelle",
                "michelle3f",
                "xxmichellezz",
                "noMatching",
            };
            string pattern = @"\S*michelle\S*";
            System.Text.RegularExpressions.Regex regx = new System.Text.RegularExpressions.Regex(pattern);
            var matchedList = myList.Where(m => regx.IsMatch(m)).ToList();
            foreach(var match in matchedList)
            {
                Console.WriteLine(match);
            }
            // end of main method
        }
        
       
     
