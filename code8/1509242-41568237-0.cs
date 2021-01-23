    public <#=code.Escape(codeStringGenerator.PascalCase(entity))#>()
    {
    <#
        foreach (var edmProperty in propertiesWithDefaultValues)
        {
    #>
        this.<#=code.Escape(edmProperty)#> = <#=typeMapper.CreateLiteral(edmProperty.DefaultValue)#>;
    <#
        }
    
        foreach (var navigationProperty in collectionNavigationProperties)
        {
            // for readability hold the type name in a variable
            var typeName = typeMapper.GetTypeName(navigationProperty.ToEndMember.GetEntityType());
    #>
        // pascal case here
        this.<#=code.Escape(codeStringGenerator.PascalCase(navigationProperty))#> = new HashSet<<#=code.Escape(codeStringGenerator.PascalCase(typeName))#>>();
    <#
        }
    
        foreach (var complexProperty in complexProperties)
        {
    #>
        this.<#=code.Escape(complexProperty)#> = new <#=typeMapper.GetTypeName(complexProperty.TypeUsage)#>();
    <#
        }
    #>
    }
