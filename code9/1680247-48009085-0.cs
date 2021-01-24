	using System;
	using System.Reflection;
						
	public class Program
	{
		public static void Main()
		{
			var obj = new SerializableType();
            // reflection version of "obj is _SerializableType":
			if(typeof(_SerializableType).IsAssignableFrom(obj.GetType()))
			{
				var info = typeof(_SerializableType).GetField("name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				var name = info.GetValue(obj);
				Console.WriteLine(name);
			}
		}
	}
	public abstract class _SerializableType
	{
		public string name = "xyz";
	}
	public class SerializableType : _SerializableType { }
