    public T UpdateProperty<T>(T oldValue, T newValue)
    {
        if (!object.Equals(oldValue, newValue) && this.ObjectState != ObjectState.New && this.ObjectState != ObjectState.Deleted)
        {
            this.ObjectState = ObjectState.Changed;
        }
        return newValue;
    }
