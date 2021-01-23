    public XmlPatternTree(IReadOnlyList<string> nodeNames, 
      IReadOnlyList<IReadOnlyList<string>> attributeNames,
      IReadOnlyList<IReadOnlyList<string>> attributeValues) : this()
    {
      NodeNames = nodeNames;
      AttributeNames = attributeNames;
      AttributeValues = attributeValues;
    }
    public IReadOnlyList<string> NodeNames { get; private set; }
    public IReadOnlyList<IReadOnlyList<string>> AttributeNames  { get; private set; }
    public IReadOnlyList<IReadOnlyList<string>> AttributeValues { get; private set; }
    public int Depth => NodeNames.Count;
