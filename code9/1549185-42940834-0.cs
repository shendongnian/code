        EntityEntry<Relationship> rel1 = DbContext.Relationships.Add(new Relationship()
    {
        UserId = authorId,
        Title = "Relationship 1",
        Description = "Relationship 1",
        CreatedDate = createdDate,
        LastModifiedDate = lastModifiedDate
    });
    EntityEntry<Relationship> rel2 = DbContext.Relationships.Add(new Relationship()
    {
        UserId = authorId,
        Title = "Relationship 2",
        Description = "Relationship 2",
        CreatedDate = createdDate,
        LastModifiedDate = lastModifiedDate,
        InverseRelationship = rel1.Entity
    });
    EntityEntry<Relationship> rel3 = DbContext.Relationships.Add(new Relationship()
    {
        UserId = authorId,
        Title = "Relationship 3",
        Description = "Relationship 3",
        CreatedDate = createdDate,
        LastModifiedDate = lastModifiedDate
    });
    EntityEntry<Relationship> rel4 = DbContext.Relationships.Add(new Relationship()
    {
        UserId = authorId,
        Title = "Relationship 4",
        Description = "Relationship 4",
        CreatedDate = createdDate,
        LastModifiedDate = lastModifiedDate,
        InverseRelationship = rel3.Entity
    });
    DbContext.SaveChanges();
    rel1.Entity.InverseRelationship = rel2.Entity;
    rel3.Entity.InverseRelationship = rel4.Entity;
    DbContext.SaveChanges();
