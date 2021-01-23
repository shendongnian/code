    public class ClassA
    {
        static Dictionary<string,string> codeToCountryLookup
             = new Dictionary<string,string>();
        protected string country { get; set; }
        public ClassA(string code)
        {
           if(!codeToCountryLookup.ContainsKey(code))
                codeToCountryLookup.Add(code,CallsomeService(code));
           country = codeToCountryLookup[code];
        }
    }
