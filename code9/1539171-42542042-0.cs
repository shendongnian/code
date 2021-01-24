	using System;
	using System.Reflection;
	namespace EnumGames
	{
		public class Program
		{
			static void Main(string[] args)
			{
				SomeClass sc = new SomeClass();
				var ans = sc.GetEnumValue("MyEnum", "OptionB");
			}
		}
		public class SomeClass
		{
			public enum MyEnum
			{
				OptionA,
				OptionB,
				OptionC
			}
			public enum MyOtherEnum
			{
				OptionA,
				OptionB,
				OptionC
			}
			public string GetEnumValue(string enumNameString, string enumOptionString)
			{
				var assembly = Assembly.GetExecutingAssembly();
				var enumType = assembly.GetType($"{this.ToString()}+{enumNameString}");
				var enumOption = Enum.Parse(enumType, enumOptionString);
				return GetEnumValue(enumOption);
			}
			private string GetEnumValue(object enumOption)
			{
				if (enumOption is MyEnum)
				{
					switch ((MyEnum)enumOption)
					{
						case MyEnum.OptionA:
							return "Hi";
						case MyEnum.OptionB:
							return "Hello";
						case MyEnum.OptionC:
							return "Yo";
						default:
							return "Nope";
					}
				}
				else if (enumOption is MyOtherEnum)
				{
					switch ((MyOtherEnum)enumOption)
					{
						case MyOtherEnum.OptionA:
							return "Bye";
						case MyOtherEnum.OptionB:
							return "Ta-Ta!";
						case MyOtherEnum.OptionC:
							return "Goodbye";
						default:
							return "Nopee";
					}
				}
				return "Nooope";
			}
		}
	}
