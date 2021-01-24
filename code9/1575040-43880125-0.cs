    /// <summary>
    /// Returns the expanded XML name in the format: {namespaceName}localName.
    /// </summary>
    public override string ToString() {
        if (ns.NamespaceName.Length == 0) return localName;
        return "{" + ns.NamespaceName + "}" + localName;
    }
