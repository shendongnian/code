	using System;
	using AutoMapper;
						
	public class Program
	{
		public static void Main()
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageDimentionsString, PackageDimentionsDecimal>());
			
			var mapper = config.CreateMapper();
			
			var m1 = new PackageDimentionsString
			{
				Width = "1000",
				Height = "4000",
				Length = "3302",
				Weight = "445"
			};
			var m2 = mapper.Map<PackageDimentionsString, PackageDimentionsDecimal>(m1);
			
			Console.WriteLine(m2.Width);
			Console.WriteLine(m2.Height);
			Console.WriteLine(m2.Length);
			Console.WriteLine(m2.Weight);
		}
	}
	public class PackageDimentionsString
	{       
		public string Width { get; set; }
		public string Height { get; set; }
		public string Length { get; set; }
		public string Weight { get; set; }
	}
	public class PackageDimentionsDecimal
	{       
		public decimal Width { get; set; }
		public decimal Height { get; set; }
		public decimal Length { get; set; }
		public decimal Weight { get; set; }
	}
