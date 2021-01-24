	using System;
	using DryIoc;
						
	public class Program
	{
		public static void Main()
		{
			var c = new Container();
			
			var localImageStoragePath = "a";
			var localImageUrl = "b";
			
			c.Register<ISqlConnection, TsqlConnection>();
			c.Register<IImageService, ProfileImageService>(
				Made.Of(() => new ProfileImageService(
					Arg.Of<ISqlConnection>(), 
					Arg.Index<string>(0), 
					Arg.Index<string>(1)), 
					_ => localImageStoragePath, 
					_ => localImageUrl));
			
			var imgService = c.Resolve<IImageService>();
			
			Console.WriteLine(imgService);
		}
		
		public interface IImageService {}
		
		public class ProfileImageService: IImageService
		{
			public ProfileImageService(ISqlConnection conn, string a, string b) {}
		
		}
		public interface ISqlConnection {}
		
		public class TsqlConnection : ISqlConnection {}	
	}
