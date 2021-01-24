    public class Parameter1 : IParameter
    
    public class Parameter2 : IParameter
    
    public class Database : IParameterList<Parameter1>, IParameterList<Parameter2>
    {
    	List<Parameter1> IParameterList<Parameter1>.ParameterList { get => parameter1List; set => parameter1List = value; }
    	List<Parameter2> IParameterList<Parameter2>.ParameterList { get => parameter2List; set => parameter2List = value; }
    	
    	...
    }
