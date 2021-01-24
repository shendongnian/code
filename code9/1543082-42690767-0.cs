    get
    {
        SetValue(ProjectUnitSystemProperty, ...); // remove this line
        return (TUnitSystemClass)GetValue(ProjectUnitSystemProperty);
    }
