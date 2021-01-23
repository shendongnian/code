    public class Employee
    {
        public IDbSet<Proposal> Proposals { get; set; } 
        public IQueryable<T> AllProposals<T>() => Proposals.OfType<ProposalCustom>();
    }
