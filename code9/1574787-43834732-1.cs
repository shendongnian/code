    public class EmailCC
    {
    	[Column("ID")]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int Id { get; set; }
    	public string Email { get; set; }
    }
