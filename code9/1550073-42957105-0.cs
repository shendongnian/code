    public class ValidatedName
    {
        // private constructor, called only by Validate method
        private ValidatedName(string name)
        {
            Name = name;
        }
        // read-only property Name
        public string Name { get; }
        // method to validate the name, returns null if name is not validate,
        // alternatively you could change this to throw an exception if name is not valid.
        public static ValidatedName? Validate(string name)
        {
            // validate name here, for example name may not be empty
            if (String.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            
            // name is not empty so return new ValidatedName object containing name
            return new ValidatedName(name);
        }
    }
