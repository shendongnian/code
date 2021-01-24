    class Person
    {
        public string Name{get;set;}
        public string[] Adjectives{get;set;}
    }
    Dictionary<string,Persons> _persons;
    var lucysAdjectives = _persons["Lucy"].Adjectives;
