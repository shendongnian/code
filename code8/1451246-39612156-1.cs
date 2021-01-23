    public ObservableCollection<ContactType> Contacs
    {
       get { return _contacs; }
       set
       {
          if(_contacs != value)
          {
             _contacs = value;
             ContactsView = CollectionViewSource.GetDefaultView(value);
             ContactsView.Filter = ContactsFilter;
          }
       }
    }
