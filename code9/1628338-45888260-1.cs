	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace YourNamespace
	{
		public sealed class Factory
		{
			private static readonly Dictionary<string, Type> TypeLookup;
			static Factory()
			{
				// You could iterate over additional assemblies if needed
				// the key is assumed to be the name of the class (case insensitive)
				TypeLookup = typeof(Factory).Assembly.GetTypes()
					.Where(t => t.IsClass && !t.IsAbstract && typeof(SomeBase).IsAssignableFrom(t))
					.ToDictionary(t => t.Name, t => t, StringComparer.OrdinalIgnoreCase);
			}
			public SomeBase Create(string name)
			{
				Type t;
				if (TypeLookup.TryGetValue(name, out t))
				{
					return (SomeBase) Activator.CreateInstance(t);
				}
				throw new ArgumentException("Could not find type " + name);
			}
		}
		public abstract class SomeBase { }
		public class Child1 : SomeBase { }
		public class Child2 : SomeBase { }
		public class Child3 : SomeBase { }
	}
	
