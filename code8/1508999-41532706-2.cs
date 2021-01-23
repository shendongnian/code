    sealed class ContactType
    {
        public static ContactType Internal { get; }
        public static ContactType External { get; }
        private ContactType()
        {
        }
        static ContactType()
        {
            // More code can fit here if creating ContactType is complicated
            Internal = new ContactType();
            External = new ContactType(); 
        }
    }
