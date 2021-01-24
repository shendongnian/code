    public object GetValue(object target)
    {
            try
            {
                if (_getter == null)
                {
                    _getter = DynamicReflectionDelegateFactory.Instance.CreateGet<object>(_memberInfo);
                }
                return _getter(target); //Line 100
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException("Error getting value from '{0}' on '{1}'.".FormatWith(CultureInfo.InvariantCulture, _memberInfo.Name, target.GetType()), ex);
            }
    }
