    public class ProgramChild2 : Program
    {
    	public ScriptableObject SelectedValue;
    	public void Test()
    	{
    		dict.Add(MyEnum2.Four.Instance, "One");
    		dict.Add(MyEnum2.Five.Instance, "Two");
    		dict.Add(MyEnum2.Six.Instance, "Three");
    		string result;
        	dict.TryGetValue(SelectedValue, out result);
    	}
    }
