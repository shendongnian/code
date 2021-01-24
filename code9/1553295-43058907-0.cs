    public class PersonRow
    {
    	public static readonly RowFields Fields = new RowFields();
    
    	public class RowFields
    	{
    		public StringField FirstName = new StringField();
    		public StringField LastName = new StringField();
    	}
    }
    
    public class StringField
    {
    	public StringField()
    	{
    		expr = Expression.Constant("It worked!");
    	}
    	public Expression expr { get; set; }
    	public string str { get; set; }
    }
