	public interface ICustomType{}    
	public struct TypeA : ICustomType {}
	public struct TypeB : ICustomType {}
	public struct TypeC : ICustomType {}
	public static T Convert<T>(ICustomType input) where T : ICustomType
	{
		var output = default(T);
		if (output is TypeA)
		{
			if (input is TypeA)
			{
				output = (T)input;
			}
			else if (input is TypeB)
			{  
                // first assign my type to ICustomType interface
                ICustomType typeA =  CustomTypeB_ToTypeA_Converter(input);
                // then cast that interface to the generic T before you return it             
				output = (T)typeA;
			}
			else if (input is TypeC)
			{  
                // first assign my type to ICustomType interface
                ICustomType typeC =  CustomTypeC_ToTypeA_Converter(input);
                // then cast that interface to the generic T before you return it             
				output = (T)typeC;
			}
		}
		else if (output is TypeB)
		{
			// same pattern as above
		}
		else if (output is TypeC)
		{
		   // same pattern as above
		}
		return output;
	}
