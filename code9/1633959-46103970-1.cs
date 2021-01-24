    public class Factory
    {
        public Evan Create(string json)
        {
            var array = JArray.Parse(json);
            string search = array[0].ToString();
            string[] terms = array[1].ToArray().Select(item => item.ToString()).ToArray();
    
            return new Evan{Search = search, Terms = terms};
        }
    }
