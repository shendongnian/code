	using System.Collections.Generic;
	public class Poll
	{
		var this.Candidates = new List<Candidate>();
		var this.MaxVotes;
		
		Poll(List<Candidate> candidates, int allowedVotes)
		{
		   this.Candidates = candidates;
		   this.MaxVotes = allowedVotes;
		}
		
		public Vote(List<Candidate> selectedCandidates)
		{
		   if (selectedCandidates.Count > this.MaxVotes)
		   {
			   // throw a new Exception or warn the user if the user has too many votes and make them fix it
		   }
		   
		   else // If the vote passes our check, we can save it to the database
		   {
			  // save the votes to the database
		   }
		}
	}
	public class Candidate
	{
		this.Name;
		
		Candidate(string name)
		{
		   this.Name = name;
		}
	}
