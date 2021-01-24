    public string GenerateFullTypeName(string name, int arity, string @namespace)
    {
        StringBuilder sb = AcquireBuilder();
        sb.Append(this.GenerateNamespace(@namespace));
        sb.Append(this.GenerateFullTypeName(name, arity));
        return GetStringAndReleaseBuilder(sb);
    }
      
    public string GenerateNamespace(string @namespace)
    {
        StringBuilder sb = AcquireBuilder();
    
        sb.Append(@namespace);
        sb.Append(".");
    
        return GetStringAndReleaseBuilder(sb);
    }
