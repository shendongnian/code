    public class This_One
    {
    	[Key, Column(Order = 1)]
    	public int CommonColumn { get; set; }
    	[Key, Column(Order = 2)]
    	public int ColumnOne { get; set; }
    	[Key, Column(Order = 3)]
    	public int ColumnTwo { get; set; }
    	[ForeignKey("CommonColumn,ColumnOne")]
    	public Other_One Other_One { get; set; }
    	[ForeignKey("CommonColumn,ColumnTwo")]
    	public Other_Two Other_Two { get; set; }
    }
