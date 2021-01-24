    Func<Data,Data> CreateNewStatement( string fields )
    {
        // input parameter "o"
        var xParameter = Expression.Parameter( typeof( Data ), "o" );
    
        // new statement "new Data()"
        var xNew = Expression.New( typeof( Data ) );
    
        // create initializers
        var bindings = fields.Split( ',' ).Select( o => o.Trim() )
            .Select( o => {
    
                // property "Field1"
                var mi = typeof( Data ).GetProperty( o );
    
                // original value "o.Field1"
                var xOriginal = Expression.Property( xParameter, mi );
    
                // set value "Field1 = o.Field1"
                return Expression.Bind( mi, xOriginal );
            }
        );
    
        // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        var xInit = Expression.MemberInit( xNew, bindings );
    
        // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        var lambda = Expression.Lambda<Func<Data,Data>>( xInit, xParameter );
    
        // compile to Func<Data, Data>
        return lambda.Compile();
    }
