    public class States
    {
        public string Country { get; set; }
        public List<string> States { get; set; }        
    }
    public IEnumerable<string> GenerateSeparatedListOfStates(string json)
    {
        var original = JsonConvert.DeserializaeObject<States>(json);
        foreach(string state in original.States)
        {
            var temp = new States 
            { 
                Country = state.Country,
                States = new List<string> { state }
            }
            yield return JsonConvert.SerializeObject(temp);
        }
    }
