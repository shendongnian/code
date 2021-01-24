    public class SomeClass
    {
        // Marking fields readonly ensures they cannot be set
        // (thus cannot be set to null) from anywhere outside 
        // of the constructor
        public readonly string field1;
        public readonly Type field2;
        public SomeClass(string field1, Type field2)
        {
            // Throwing ArgumentNullException ensures the class
            // can never be created with missing (null) values.
            if (field1 == null)
                throw new ArgumentNullException(nameof(field1));
            if (field2 == null)
                throw new ArgumentNullException(nameof(field2));
            this.field1 = field1;
            this.field2 = field2;
        }
        public string Field1
        {
            get { return field1; } // Never null
        }
        public Type Field2
        {
            get { return field2; } // Never null
        }
    }
