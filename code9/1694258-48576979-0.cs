    private void CheckInput(string oldValue, string newValue,
              string propertyName, Action<string> setterDelegate)
    {
        ...
        setterDelegate(newValue);
    }
 
    CheckInput("old", "new", nameof(value.Name), newVal => value.Name = newVal);
