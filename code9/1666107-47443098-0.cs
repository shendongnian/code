    public abstract class TipEntity : UserOwnedEntity
    {
    	/// <summary>
    	/// The "HeroSubject" of a tip is the hero this tip applies to.
    	/// </summary>
    	public Hero HeroSubject { get; set; }
    	public int? HeroSubjectId { get; set; }
    
    	//Tips can be categorized
    	public TipType Type { get; set; } = TipType.Counter;
    
    	[Required]
    	[DataType(DataType.MultilineText)]
    	public string Text { get; set; }
    
    	/// <summary>
    	/// As the game changes, tips may go out of date; tracking the
    	/// applicable patch assists with this, and users can flag a
    	/// specific tip as out of date ("deprecated").
    	/// </summary>
    	[Required]
    	public string Patch { get; set; }
    	public bool Deprecated { get; set; } = false;
    
    	/// <summary>
    	/// Where the tip was found, possibly a URL. Can give context to
    	/// a tip that isn't very intuitive.
    	/// </summary>
    	public string Source { get; set; }
    }
    
    [Table(nameof(Tip))]
    public class Tip : TipEntity
    {
    }
    
    [Table(nameof(Relationship))]
    public class Relationship : TipEntity
    {
    	public int? HeroObjectId { get; set; }
    	public Hero HeroObject { get; set; }
    }
