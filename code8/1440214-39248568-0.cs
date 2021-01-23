    public ContentSectionNode(Guid createdBy)
      : this(createdBy,null,null, null, null)
    {
    }
    
    public ContentSectionNode(Guid createdBy, string tagType, string content)
      : this(createdBy, null, null tagType, contect)
    {
    }
    
    public ContentSectionNode(Guid createdBy, Guid? parentId, int? internalParentId, string tagType, string content)
      : base(parentId, internalParentId, tagType, content)
    {
      _createdBy = createdBy;
      _createdAt = DateTime.Now;
      UpdatedAt = _createdAt;
      UpdatedBy = _createdBy;
    }
