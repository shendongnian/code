    public class CandidateManager
    {
    	//first time CandidateManager is used, it will populate backing store
    	static CandidateManager()
    	{
    		//initialize data collection
    		Candidates = new List<Candidate>();
    		GetCandidateData().ForEach(p => Candidates.Add(p));
    	}
    	/// <summary>
    	/// Backing Store
    	/// </summary>
    	private static List<Candidate> Candidates { get; set; }
    
    	/// <summary>
    	/// Returns all candidates
    	/// </summary>
    	/// <returns></returns>
    	public static List<Candidate> GetAllCandidates()
    	{
    		return Candidates;      
    	}
    
    	/// <summary>
    	/// Returns all candidates for a specified category
    	/// </summary>
    	/// <param name="candidateCategory"></param>
    	/// <returns></returns>
    	public static List<Candidate> GetCandidatesByCategory(CandidateCategoryNo candidateCategory)
    	{
    		return Candidates.Where(c => c.Category_no == candidateCategory).ToList();
    	}
    
    	/// <summary>
    	/// Returns specific candidate based on unique category/sno combination.
    	/// Returns null if no match
    	/// </summary>
    	/// <param name="candidateCategory"></param>
    	/// <param name="Sno"></param>
    	/// <returns></returns>
    	public static Candidate GetCandidateByCategoryAndSno(CandidateCategoryNo candidateCategory, CandidateSNo Sno)
    	{
    		return Candidates.Where(c => c.S_no == Sno && c.Category_no == candidateCategory).FirstOrDefault();
    	}
    
    	/// <summary>
    	/// data creation
    	/// </summary>
    	/// <returns></returns>
    	private static List<Candidate> GetCandidateData()
    	{
    		var _candidate = new List<Candidate>();
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.I, Category_no = CandidateCategoryNo.I, VoteCount = 0, Category = "Science and IT Club", Name = "A" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.II, Category_no = CandidateCategoryNo.I, VoteCount = 0, Category = "Science and IT Club", Name = "B" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.III, Category_no = CandidateCategoryNo.I, VoteCount = 0, Category = "Science and IT Club", Name = "C" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.I, Category_no = CandidateCategoryNo.II, VoteCount = 0, Category = "Dance Club", Name = "D" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.II, Category_no = CandidateCategoryNo.II, VoteCount = 0, Category = "Dance Club", Name = "E" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.III, Category_no = CandidateCategoryNo.II, VoteCount = 0, Category = "Dance Club", Name = "F" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.I, Category_no = CandidateCategoryNo.III, VoteCount = 0, Category = "Music Club", Name = "G" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.II, Category_no = CandidateCategoryNo.III, VoteCount = 0, Category = "Music Club", Name = "H" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.III, Category_no = CandidateCategoryNo.III, VoteCount = 0, Category = "Music Club", Name = "I" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.I, Category_no = CandidateCategoryNo.IV, VoteCount = 0, Category = "Social Service Club", Name = "J" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.II, Category_no = CandidateCategoryNo.IV, VoteCount = 0, Category = "Social Service Club", Name = "K" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.III, Category_no = CandidateCategoryNo.IV, VoteCount = 0, Category = "Social Service Club", Name = "L" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.I, Category_no = CandidateCategoryNo.V, VoteCount = 0, Category = "Sports Club", Name = "M" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.II, Category_no = CandidateCategoryNo.V, VoteCount = 0, Category = "Sports Club", Name = "N" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.III, Category_no = CandidateCategoryNo.V, VoteCount = 0, Category = "Sports Club", Name = "O" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.I, Category_no = CandidateCategoryNo.VI, VoteCount = 0, Category = "School Captain", Name = "P" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.II, Category_no = CandidateCategoryNo.VI, VoteCount = 0, Category = "School Captain", Name = "Q" });
    		_candidate.Add(new Candidate() { S_no = CandidateSNo.III, Category_no = CandidateCategoryNo.VI, VoteCount = 0, Category = "School Captain", Name = "R" });
    		return _candidate;
    	}
    }
