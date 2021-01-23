    namespace myNameSace
    {
    
    class GetAuto
    {
        public GetAuto()
        {
            string text = "cars";
            foreach (var item in GetAutoComplete(text))
            {
                Console.WriteLine(item);
            } 
        }
        private List<string> GetAutoComplete(string text)
        {
            var lookForSimilarities = Regex.Match(text,"ars");
            
            var autoComplete = new List<string>();
            
            if (lookForSimilarities.Success)
            {
                autoComplete.Add("cars");
                autoComplete.Add("mars");
                autoComplete.Add("wars");
                autoComplete.Add("tarso");
            }
           
            return autoComplete;
        }
     }
    }
