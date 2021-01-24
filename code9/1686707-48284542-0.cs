    public EntityBase()
    {
        this.CreatedAt = DateTimeOffset.Now;
        this.UUId = new Guid();
        this.UpdatedAt = this.CreatedAt;
    }
