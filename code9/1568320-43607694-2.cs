	namespace ConsoleApplication18
	{
		using System;
		using System.ComponentModel.Composition;
		using System.ComponentModel.Composition.Hosting;
		using System.IO;
		using System.Linq;
		public interface IPlugin
		{
			void Initialize();
		}
		class Program
		{
			private static CompositionContainer _container;
			static void Main(string[] args)
			{
				AggregateCatalog catalog = new AggregateCatalog();
				catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(Directory.GetCurrentDirectory(), "Plugins")));
				_container = new CompositionContainer(catalog);
				IPlugin plugin = null;
				try
				{
					_container.ComposeParts();
                    
                    // GetExports<T> returns an IEnumerable<Lazy<T>>, and so Value must be called when you want an instance of the object type.
					plugin = _container.GetExports<IPlugin>().ToArray()[0].Value;
				}
				catch (CompositionException compositionException)
				{
					Console.WriteLine(compositionException.ToString());
				}
				plugin.Initialize();
				Console.ReadKey();
			}
		}
	}
