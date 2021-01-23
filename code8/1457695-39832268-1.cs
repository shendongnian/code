	public class Question {
	  ... 
	  public Riddle Riddle { get; set; }
	  public int RiddleId { get; set; }
	  [Column(TypeName = "datetime2")]
	  public DateTime CreationDate { get; set; }
	  ...
	}
