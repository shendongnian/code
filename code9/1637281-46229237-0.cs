    public class Term
    {
        public string Known { get; set; }
        public string Word { get; set; }
    }
    public class Response
    {
        public List<TermWrapper> MyTerms { get; set; }
    }
    public class TermWrapper
    {
        public Term Term { get; set; }
    }
    ...
    var response = await httpClient.GetAsync(uri);
    string responseString = response.Content.ReadAsStringAsync().GetResults();
    var searchTermList = JsonConvert
        .DeserializeObject<Response>(responseString)
        .MyTerms
        .Select(x => x.Term);
