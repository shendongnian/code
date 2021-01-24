    public class ContactsViewModel
    {
        private readonly ObservableCollection<Contact> _Contacts
            = new ObservableCollection<Contact>();
    
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
    
        private ContactGroupsViewModel _ContactGroupsViewModel 
            = new ContactGroupsViewModel();
        private ContactGroupsViewModel ContactGroup
        {
            get { return _ContactGroupsViewModel; }
            set
            {
                _ContactGroupsViewModel = value;
                RaisePropertyChangedEvent("ContactGroup");
                RaisePropertyChangedEvent("Contacts");
            }
        }    
    }
