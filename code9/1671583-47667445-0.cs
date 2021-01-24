	using System;
	using System.IO;
	using System.Linq;
	namespace StackOverflow
	{
		public class App_DepartmentPay
		{
			public void Run()
			{
				var lines = File.ReadAllLines(@"d:\temp\payments.txt");
				var payStubs = lines.Select(l => new PayStub(l)).ToList();
				
				var departmentTotals = payStubs.GroupBy(p => p.Department).Select(g => new DepartmentTotal(g.Key, g.Sum(w => w.Pay))).ToList();
				departmentTotals.ForEach(t => Console.WriteLine(t.ToString()));
			}
		}
		public class PayStub
		{
			public string EmployeeId { get; private set; }
			public int Department { get; private set; }
			public decimal HourlyWage { get; private set; }
			public decimal HoursWorked { get; private set; }
			public decimal Pay
			{
				get
				{
					return HourlyWage * HoursWorked;
				}
			}
			public PayStub(string payLine)
			{
				var contents = payLine.Split(',');
				EmployeeId = contents[0];
				Department = int.Parse(contents[1]);
				HourlyWage = decimal.Parse(contents[2]);
				HoursWorked = decimal.Parse(contents[3]);
			}
		}
		public class DepartmentTotal
		{
			public int Department { get; set; }
			public decimal TotalPay { get;  set; }
			public DepartmentTotal(int department, decimal pay)
			{
				Department = department;
				TotalPay = pay;
			}
			
			public override string ToString()
			{
				return $"Department: {Department} \tGross Pay: {TotalPay}";
			}
		}
	}
