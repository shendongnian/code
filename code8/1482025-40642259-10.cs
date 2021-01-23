    private bool TryValidateProperty(PropertyInfo propertyInfo, List<string> propertyErrors)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(this) { MemberName = propertyInfo.Name };
        var propertyValue = propertyInfo.GetValue(this);
    
        // Validate the property
        var isValid = Validator.TryValidateProperty(propertyValue, context, results);
    
        if (results.Any()) { propertyErrors.AddRange(results.Select(c => c.ErrorMessage)); }
    
        return isValid;
    }
    
    /// <summary>
    /// Is called by the indexer to collect all errors and not only the one for a special field.
    /// </summary>
    /// <remarks>
    /// Because <see cref="HasErrors" /> depends on the <see cref="Errors" /> dictionary this
    /// ensures that controls like buttons can switch their state accordingly.
    /// </remarks>
    private void CollectErrors()
    {
        Errors.Clear();
        PropertyInfos.ForEach(
            prop =>
            {
                //Validate generically
                var errors = new List<string>();
                var isValid = TryValidateProperty(prop, errors);
                if (!isValid)
                    //As you're using a dictionary to store the errors and the key is the name of the property, then add only the first error encountered. 
                    Errors.Add(prop.Name, errors.First());
            });
        // we have to this because the Dictionary does not implement INotifyPropertyChanged            
        OnPropertyChanged(nameof(HasErrors));
        OnPropertyChanged(nameof(IsOk));
        // commands do not recognize property changes automatically
        OnErrorsCollected();
    }
