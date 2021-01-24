    public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
    {
        Configuration.LazyLoadingEnabled = false;
    }
