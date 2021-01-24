    public static void Main()
	{
		_genericMapInfo = typeof(Program).GetMethod("map", BindingFlags.NonPublic | BindingFlags.Static);
		Test t = null;
		map(ref t);
		Console.WriteLine(t == null); // False
		Console.WriteLine(t.A); // Hello World!
		Console.WriteLine(t.B.A); // 1337
		Console.WriteLine(t.B.B); // Hello World!
    }
	
	static MethodInfo _genericMapInfo;
	
	static void map<T>(ref T obj)
		where T : class
	{
		if(obj == null)
			obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
			
		foreach(FieldInfo fInfo in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
		{
		    Type fieldType = fInfo.FieldType;	
			TypeCode tCode = Type.GetTypeCode(fInfo.FieldType);
			if(tCode == TypeCode.Object)
			{
				object[] param = new object[] { fInfo.GetValue(obj) };
				_genericMapInfo.MakeGenericMethod(fieldType).Invoke(null, param);
				fInfo.SetValue(obj, param[0]);
			}
			else if(tCode == TypeCode.String)
			{
			    fInfo.SetValue(obj, "Hello World!");	
			}
			else if(tCode == TypeCode.Int32)
			{
			    fInfo.SetValue(obj, 1337);	
			}
				
		}
	}
	
	public class Test
	{
		public string A { get; set; }	
		public TestInside B { get; private set; }
		
		public Test()
		{
			A = "no siema";	
		}
	}
	
	public class TestInside
	{
		public int A { get; private set; }
		public string B { get; set; }	
		
		public TestInside(int _someInteger)
		{
			A = _someInteger;	
		}
	}
