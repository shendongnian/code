    public class Parent
    {
        public List<Attribute> attrList{ get; set; }
    }
    
    public class Attribute
    {
        public string name{ get; set; }
        public string val{ get; set; }
    }
    
    var parsedParent = JsonConvert.DeserializeObject<Parent>(
       "{ 'attrList':[ { 'name':'Attendee Status', 'val':'Accepted' }, { 'name':'Attendee Type', 'val':'Attendee' } ] }"
    );
