    void MyThing()
    {
        // Some hard validations here like foo != null
        using (var handler = new WarningsHandler())
        {
            handler.Validate(foo.Count > 2, () => new Warning("You should have at least 2 foo's present.");
        }
        // Some hard validations here as well
    } 
