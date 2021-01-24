    public ViewModel()
    {
        CreateCommand = new RelayCommand(x => Create(), CanCreate);
    }
    protected bool CanCreate(object sender)
    {
        if (Validator.TryValidateObject(this, new ValidationContext(this, null, null), new List<ValidationResult>(), true))
            return true;
        else
            return false;
    }
    protected void Create()
    {
        var vendor = new Vendor(Name, Phone);
        UnitOfWork.Vendors.Add(vendor);
    }
