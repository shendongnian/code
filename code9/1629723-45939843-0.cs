    private MyObject myObject;
    // gets or sets the currently bound object
    public MyObject MyObject
    {
        get
        {
            return myObject;
        }
        set
        {
            myObject = value;
            myObjectBindingSource.RaiseListChangedEvents = false;
            myObjectBindingSource.EndEdit();
            // rebind
            myObjectBindingSource.DataSource = null;
            myObjectBindingSource.DataSource = myObject;
            myObjectBindingSource.RaiseListChangedEvents = true;
            myObjectBindingSource.ResetBindings(false);
        }
    }
