    [System.Serializable]
    public class GetPeopleResult
    {
        public List<Person> people;
        public GetPeopleResult()
        {
           this.people = new List<People>();
        }
    
        public static GetPeopleResult CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<GetPeopleResult>(jsonString);
        }
    
    }
    [System.Serializable]
    public class Person
    {
        public long id;
        public string name;
        public string email;
        public string displayImageUrl;
    
        public Person()
        {
    
        }
        public static Person CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<Person>(jsonString);
        }
    }
