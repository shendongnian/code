    public class EmailAdapter : BaseAdapter
    {
        List<Contact> _contactList;
        Activity _activity;
    
        public ContactsAdapter (Activity activity)
            {
                _activity = activity;
                FillEmail ();
            }
    
        void FillEmail ()
        {
            //Logic to fill email
        }
    
        class Email
        {
            public long Id { get; set; }
            public string DisplayName{ get; set; }
        }
    }
