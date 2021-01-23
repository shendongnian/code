    private static readonly Dictionary<String,PropertyInfo> _properties = typeof(MyClass).GetProperties().ToDictionary( pi => pi.Name );
    
    public IEnumerable<MyClass>Search(MyClass prototype, IEnumerable<String> propertiesToFilter, IEnumerable<MyClass> items) {
        IEnumerable<PropertyInfo> selectedProperties = propertiesToFilter
            .Select( name => _properties[ name ] )
            .ToList();
        return items
            .Where( i => selectedProperties
                .Select( pi => pi.GetValue( i )
                .SequenceEquals( _selectedProperties
                    .Select( pi => pi.GetValue( prototype ) )
            );
    }
