    using System;
	using System.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		class Company
		{
			public string CompanyID { get; set; }
			public string CompanyName { get; set; }
			public string AliasList { get; set; }
		}
		
		class Empl
		{
			public string EmplID { get; set; }
			public string EmployerName { get; set; }
		}
		
		public static void Main()
		{
			Case1();
			Case2();
			Case3();
		}
		
		static void Case1()
		{
			//CompanyName == EmployerName
			List<Empl> listEmpl = new List<Empl>() { new Empl() { EmplID = "1", EmployerName = "Walmart" } };
			List<Company> listCompany = new List<Company>() { new Company() { CompanyID = "1", CompanyName = "Walmart", AliasList = "Wal-mart;Wal Mart;Samsclub" } };
			
			var result = from e in listEmpl
				from c in listCompany.Where(w => w.CompanyName.Trim() == e.EmployerName.Trim() || w.AliasList.Split(';').Contains(e.EmployerName.Trim()))
				select new { c.CompanyName, e.EmployerName };
			
			if(result.FirstOrDefault() != null)
			{
				Console.WriteLine(result.FirstOrDefault().CompanyName);
			}
			else
			{
				Console.WriteLine("Result is empty!");
			}
		}
		
		static void Case2()
		{
			//AliasList Contain EmployerName
			List<Empl> listEmpl = new List<Empl>() { new Empl() { EmplID = "1", EmployerName = "Wal-mart" } };
			List<Company> listCompany = new List<Company>() { new Company() { CompanyID = "1", CompanyName = "Walmart", AliasList = "Wal-mart;Wal Mart;Samsclub" } };
			
			var result = from e in listEmpl
				from c in listCompany.Where(w => w.CompanyName.Trim() == e.EmployerName.Trim() || w.AliasList.Split(';').Contains(e.EmployerName.Trim()))
				select new { c.CompanyName, e.EmployerName };
			
			if(result.FirstOrDefault() != null)
			{
				Console.WriteLine(result.FirstOrDefault().CompanyName);
			}
			else
			{
				Console.WriteLine("Result is empty!");
			}
		}
		
		static void Case3()
		{
			//Not match any condition
			List<Empl> listEmpl = new List<Empl>() { new Empl() { EmplID = "1", EmployerName = "Wal - mart" } };
			List<Company> listCompany = new List<Company>() { new Company() { CompanyID = "1", CompanyName = "Walmart", AliasList = "Wal-mart;Wal Mart;Samsclub" } };
			
			var result = from e in listEmpl
				from c in listCompany.Where(w => w.CompanyName.Trim() == e.EmployerName.Trim() || w.AliasList.Split(';').Contains(e.EmployerName.Trim()))
				select new { c.CompanyName, e.EmployerName };
			
			if(result.FirstOrDefault() != null)
			{
				Console.WriteLine(result.FirstOrDefault().CompanyName);
			}
			else
			{
				Console.WriteLine("Result is empty!");
			}
		}
	}
