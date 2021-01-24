    [ForeignKey("Branch")]
    [Index("BranchEmp", IsUnique = true, Order = 1)]
    [Index("BranchDev", IsUnique = true, Order = 1)]
    public long BranchId { get; set; }
    
    [Index("BranchEmp", IsUnique = true, Order = 2)]
    public string DevRegNumber { get; set; }
    
    [Index("BranchDev", IsUnique = true, Order = 2)]
    public string EmployeeNumber { get; set; }
