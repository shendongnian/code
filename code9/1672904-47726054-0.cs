    internal class Helper
    {
        public string _name {get;set;}
        public string _id {get;set;}
        
        public IObject GetAOrBObject()
        {
            if (_id.Length == 32) // Assume GUID with no separator like '-'
            {
                return new A() { Name = _name, ID = Guid.Parse(_id) };
            }
            else
            {
                return new B() { Name = _name, ID = int.Parse(_id) };
            }
        }
    }
