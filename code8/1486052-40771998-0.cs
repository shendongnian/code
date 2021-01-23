    public class Election
    {
        public int Id { get; set; }
        public int TotalVotes { get; set; }
        public List<Candidate> Candidates { get; set; }
        public void AddCandidate(Candidate c)
        {
            Candidates.Add(c);
        }
        public List<Candidates> SortCandidates()
        {
            return Candidates.OrderByDescending(k => k.NumVotes).ToList();
        }
    }
    public class Candidate
    {
         public string Name { get; set; }
         public int NumVotes { get; set; }        
    }
