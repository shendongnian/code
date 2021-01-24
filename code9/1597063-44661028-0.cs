	public class Enemy
	{
		public List<string> Likes { get; set; }
		
		public Enemy()
		{
			Likes = new List<string>()
			{ 
				"loitering", 
				"puppies" 
			};
		}
	}
	public partial class Skater : Enemy
	{
		public Skater()
		{
			Likes.Add("skateboarding");
		}
	}
