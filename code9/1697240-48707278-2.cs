    public class Parameter1 : IParameter
    {
    	public string Code { get; set; }
    	public string Label { get; set; }
    	public List<Parameter1Value> paramValues;
    }
    
    public class Parameter2 : IParameter
    {
    	public string Code { get; set; }
    	public string Label { get; set; }
    	public List<Parameter2Value> paramValues;
    }
    
    public class Parameter1Value
    {
    	public string Value { get; set; }
    	public Parameter parameter { get; set; }
    }
    
    public class Parameter2Value
    {
    	public int Value { get; set; }
    	public Parameter2 parameter { get; set; }
    }
    
    public class Database : IParameterList<Parameter1>, IParameterList<Parameter2>
    {
    	public List<Parameter1> parameter1List { get; set; } = new List<Parameter1>();
    	public List<Parameter2> parameter2List { get; set; } = new List<Parameter2>();
    
    	List<Parameter1> IParameterList<Parameter1>.ParameterList { get => parameter1List; set => parameter1List = value; }
    	List<Parameter2> IParameterList<Parameter2>.ParameterList { get => parameter2List; set => parameter2List = value; }
    
    	public static TParameter Add<TParameter>(IParameterList<TParameter> db, string code, string label) where TParameter : IParameter, new()
    	{
    		var itemToCreate = new TParameter();
    		itemToCreate.Code = code;
    		itemToCreate.Label = label;
    		db.ParameterList.Add(itemToCreate); // Add the newly created parameter to the correct list
    		return itemToCreate;
    	}
    }
    
    public interface IParameter
    {
    	string Code { get; set; }
    	string Label { get; set; }
    }
    
    public interface IParameterList<TParameter> where TParameter : IParameter
    {
    	List<TParameter> ParameterList { get; set; }
    }
    
    // Testing:
    void Main()
    {
    	var db = new Database();
    	Database.Add<Parameter1>(db, "hello", "hello2");
    	Database.Add<Parameter1>(db, "hello", "hello2");
    	Database.Add<Parameter2>(db, "hello", "hello2");
    	Console.WriteLine($"P1 count (should be 2): {db.parameter1List.Count()}; P2 count (should be 1): {db.parameter2List.Count}");
    }
