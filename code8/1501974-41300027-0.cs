    public class Employee
    {
        public IDbSet<Proposal> Proposals { get; set; } 
        [NotMapped]
        public IQueryable<ProposalCustom> CreatedProposalCustoms { get; } => Proposals.OfType<ProposalCustom>();
        [NotMapped]
        public IQueryable<ProposalLeave> CreatedProposalLeaves { get; } => Proposals.OfType<ProposalLeave>();
    }
