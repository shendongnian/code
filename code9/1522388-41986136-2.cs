	public class NumericAttribute : Characteristic<Int32>
	{
		void f()
		{
			var _modifiedValue = Value.Modify(new Int32() { Value = 1 });
		}
	}
	public class StringAttribute : Characteristic<String>
	{
		void f()
		{
			var _modifiedValue = Value.Modify(new String() { Value = " more text." });
		}
	}
