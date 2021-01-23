    sealed class ContactType
    {
        public static ContactType Internal { get; } = new ContactType();
        public static ContactType External { get; } = new ContactType();
        private ContactType()
        {
        }
    }
