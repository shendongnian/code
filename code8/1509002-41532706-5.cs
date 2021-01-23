    sealed class ContactType
    {
        private readonly string contactTypeName;
        public static ContactType Internal { get; } = new ContactType("Internal");
        public static ContactType External { get; } = new ContactType("External");
            
        private ContactType(string contactTypeName)
        {
            this.contactTypeName = contactTypeName;
        }
        public override string ToString()
        {
            // Note that these two ways of building this string are equivalent.
            // You may be more familiar with the old commented out way, but C# 6 added this new interpolation syntax.
            // Take your pick between the two, I prefer the interpolation.
            //return "Contact of type " + this.ContactTypeName;
            return $"Contact of type {this.contactTypeName}";
        }
    }
