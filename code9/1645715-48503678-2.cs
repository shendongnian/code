    T selectedItem;
    public T SelectedItem
    {
      get { return selectedItem; }
      set { SetProperty( ref selectedItem, value, MaybeSelectItem ); }
    }
    void MaybeSelectItem( )
    {
      if ( SelectItem.CanExecute( null ) )
      {
        SelectItem.Execute( null );
      }
    }
