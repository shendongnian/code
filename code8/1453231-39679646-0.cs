    class ExactResult {
    	public String CombinedId { get; set; }
    	public int Count { get; set; }
    }
    resultList.Select(l => {
		var combinedId = l.Winner.Id.ToString() + l.Second.Id.ToString() + l.Third.ToString() + l.Fourth.ToString();
		return new ExactResult() { CombinedId = combinedId), Count = l.Count(c => c.Winner.Id.ToString() + c.Second.Id.ToString() + c.Third.ToString() + c.Fourth.ToString();)}
	}).OrderByDescending(e => e.Count).Take(50)
