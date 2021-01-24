    public bool IsValid()
    {
        var allListItemsValid = myList.All(x => x.IsValid());   
        var validator = ValidationFactory.CreateValidator<YourViewModel>();
        return validator.Validate(this).IsValid && allListItemsValid;
    }
