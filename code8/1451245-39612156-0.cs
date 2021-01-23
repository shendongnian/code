    ICollectionView contactsView;
    
    public ICollectionView ContactsView
    {
       get { return contactsView; }
       set 
       { 
          if(contactsView != value)
          {
              contactsView = value;
          }
       }
    }
