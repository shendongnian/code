    public class GroupEventualityDto<T>
    {
    	public int Id { get; set; }
    	public int IdGroup { get; set; }
    	public int IdEventuality { get; set; }
    	public T Value { get; set; }
    
    	public GroupEventualityDto(){
    		if(!(Value is int || Value is decimal || Value is string)) throw new ArgumentException("The GroupEventualityDto generic type must be either an int, decimal or string");
    	}
    }
