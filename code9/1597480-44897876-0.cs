    private void PropertyChanged(object sender, PropertyChangedEventArgs e)
    { 
        var car = (Car)sender;
        var newValue = GetPropertyValueByReflection(car, e.PropertyName);
        object existingTarget;
        if ((newValue == null) && IsAdded(car) &&
             ThereExistsAnExistingLink(car, e.PropertyName, out existingTarget))
            _odata.DetachLink(car, e.PropertyName, existingTarget);
        else
            _odata.SetLink(car, e.PropertyName, newValue);
    }
    private bool IsAdded(object entity)
    {
        return _odata.GetEntityDescriptor(entity).State.HasFlag(EntityStates.Added);
    }
    private bool ThereExistsAnExistingLink(object entity, 
                                           string propertyName, 
                                           out object existingTarget)
    {
        var linkDescriptor = _context.Links.FirstOrDefault(
                               ld => ld.Source == _source && 
                                     ld.SourceProperty == _sourceProperty &&
                                    !ld.HasStates(EntityStates.Detached)
                               );
        if (linkDescriptor != null)
        {
            existingTarget = linkDescriptor.Target;
            return true;
        }
        existingTarget = null;
        return false;
    }
