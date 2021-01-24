    public class CharCollection
    {
        public CharCollection(string key, IEnumerable<char> characters = null) 
        {
            Key = key;      
            Characters = new List<char>();
   
            if(characters != null)
            {
                Characters.AddRange(characters);
            }
        }
        public List<char> Characters { get; set; }
        public string Key { get; }   
        public int Count { get { return Characters.Count; } }
        public int Capacity { get { return Characters.Capacity; } } 
    }
