    private Dictionary<string, string> GenerateQueryParameters(object queryParameters)
    {
        var startStop = new StartStop() { Start = queryParameters.Start, Stop = queryParameters.Stop};
        var result = new Dictionary<string, string>();
        result.Add(queryParameters.Name, startStop);
        return result;
    }
    public class StartStop
    {
        public int Start { get; set; }
        public int Stop { get; set; }
    }
