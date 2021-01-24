    using System;
	using DryIoc;
						
	public class Program
	{
		public static void Main()
		{
			var container = new Container();
			
			container.Register<ParentViewModel>();
			
			container.Register<FirstViewModel>(Reuse.Singleton);
			
			container.Register<SecondViewModel>(Reuse.Singleton, 
				made: PropertiesAndFields.Of.Name("A", r => r.Container.Resolve<FirstViewModel>().A));
	
			var firstVM = container.Resolve<FirstViewModel>();
			firstVM.A = "blah";
			
			var secondVM = container.Resolve<SecondViewModel>();
			
			Console.WriteLine(secondVM.A); // should output "blah"
		}
		
		public class ParentViewModel {
		}
		
		public class FirstViewModel {
		   public FirstViewModel(ParentViewModel parent) { }
		   public string A { get; set; }
		}
		
		public class SecondViewModel {
		   public SecondViewModel(ParentViewModel parent) {}
		   public string A { get; set; }
		}
	}
