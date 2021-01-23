    using System;
    using System.Reflection;
    using System.Diagnostics;
					
    public class Program
    {
	
	public class Worker
	{
		public string Id1 {get; set;}
		public string Id2 {get; set;}
		public string Id3 {get; set;}
		
		public string ModelName {get; set;}
	}
	
	public interface IModel
	{
	}
	
	public class Model1: IModel
	{
	}
	
	public class Model2: IModel
	{
	}
	
	public class ModelActor <TModel> where TModel: IModel
	{
		private Lazy<Worker> _worker = new Lazy<Worker>(
			() => {
					Console.WriteLine("Worker Instance created");
				
					return new Worker() 
					{
						Id1 = new StackFrame().GetMethod().DeclaringType.Name,
						Id2 = MethodBase.GetCurrentMethod().DeclaringType.Name,
						Id3 = typeof(ModelActor <TModel>).Name,
							
						ModelName = typeof(TModel).Name
					};
			}
		);
		
		public Worker Worker
		{
			get
			{
				return _worker.Value;
			}
		}
	}
	
	
	public class ModelActor2 <TModel> where TModel: IModel
	{
		private Lazy<Worker> _worker = new Lazy<Worker>(
			() => {
					Console.WriteLine("Worker Instance created");
				
					return new Worker() 
					{
						Id1 = new StackFrame().GetMethod().DeclaringType.Name,
						Id2 = MethodBase.GetCurrentMethod().DeclaringType.Name,
						Id3 = typeof(ModelActor <TModel>).Name,
							
						ModelName = typeof(TModel).Name
					};
			}
		);
		
		public Worker Worker
		{
			get
			{
				return _worker.Value;
			}
		}
	}
	
	public class ModelActor1: ModelActor<Model1>
	{
	}
	
	public class ModelActor2: ModelActor2<Model2>
	{
	}
	
	public static void Main()
	{
		Console.WriteLine("Id1: {0} {1}", new ModelActor1().Worker.Id1,  new ModelActor2().Worker.Id1);
		Console.WriteLine("Id2: {0} {1}", new ModelActor1().Worker.Id2,  new ModelActor2().Worker.Id2);
		Console.WriteLine("Id3: {0} {1}", new ModelActor1().Worker.Id3,  new ModelActor2().Worker.Id3);
		
		Console.WriteLine("Want to get: ModelActor1 ModelActor2\n");
		
		Console.WriteLine("ModelName: {0} {1}", new ModelActor1().Worker.ModelName,  new ModelActor2().Worker.ModelName);
		Console.WriteLine("No problem with model name.");
	}
    }
