    public class ContactsViewModel
    {    
        public IEnumerable<Contact> Contacts
        {
            get 
            { 
                return db.Contacts.Where
                (
                    x => x.ContactGroupId == ContactGroup.Id &&
                    x.Deleted == false
                ); 
            }
        }
    
        private ContactGroup _contactGroup = new ContactGroup();
        private ContactGroup ContactGroup
        {
            get { return _contactGroup; }
            set
            {
                _contactGroup = value;
                RaisePropertyChangedEvent("ContactGroup");
                RaisePropertyChangedEvent("Contacts");
            }
        }  
        private ObservableCollection<ContactGroup> _ContactGroups 
        = new ObservableCollection<ContactGroup>();
        private IEnumerable<ContactGroup> ContactGroups
        {
            get { return _ContactGroupsViewModel; }
        }  
    }
