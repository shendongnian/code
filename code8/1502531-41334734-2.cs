    db.Proposal.Add(new ProposalLeave
    {
    	Substantiation = "S1",
    	DateCreated = DateTime.Today,
    	LeaveStart = DateTime.Today,
    	LeaveEnd = DateTime.Today,
    	LeaveType = new ProposalLeaveType { Name = "PLT1", Description = "PLT1" }
    });
    db.Proposal.Add(new ProposalCustom
    {
    	Substantiation = "S2",
    	Name = "PC1",
    	ProposalType = new ProposalCustomType { Name = "PCT1", Description = "PCT1" }
    });
    db.SaveChanges();
