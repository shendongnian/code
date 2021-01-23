    // These are a representation of your classes :
	public class Line
	{
		public int LineId { get; set; }
		public string SomeValue { get; set;}
	}
	
	public class Revision
	{
		public int RevisionId { get; set; }
		public int LineId { get; set;}	
	}
	
	void Main()
	{
        // generating some data so we can test the query.
		var lines = new List<Line>() { 
			new Line() { LineId = 1, SomeValue = "Allo!" } 
			};
		
		var revisions = new List<Revision>() { 
			new Revision() { LineId = 1, RevisionId = 1 }, 
			new Revision() { LineId = 1, RevisionId = 2 }, 
			new Revision() { LineId = 1, RevisionId = 3 }
			};
		
		var result = (
			from line in lines
			join revision in revisions on line.LineId equals revision.LineId
			group revision by line into grp
			select new
			{
				Line = grp.Key,
				LastRevision = grp.OrderByDescending(rev => rev.RevisionId).FirstOrDefault()
			}
			).ToList();
	}
