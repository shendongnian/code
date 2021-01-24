	using System;
	using System.IO;
	//using System.Collections.Generic;
	//using System.Linq;
	//using System.Text;
	//using System.Threading.Tasks;
	namespace Assignment_2 {
		class Program {
			static void Main() {
				string InputPath = @"C:\Users\....\Desktop\CP Class\Assignment 2\Asgn2InputFile.txt";
				string OutputPath = @"C:\Users\....\Desktop\CP Class\Assignment 2\Payroll.txt";
				using (StreamReader sr = new StreamReader(InputPath))
				using (StreamWriter sw = new StreamWriter(OutputPath)) {
					sw.Write("NAME".PadRight(11));
					sw.Write("HOURS WORKED ".PadRight(23));
					sw.Write("PAY RATE".PadRight(20));
					sw.Write("OVERTIME".PadRight(27));
					sw.WriteLine();
					// input line
					string InputLine;
					while ((InputLine = sr.ReadLine()) != null) {
						//  parse input line
						var First = InputLine.Substring(0, 5);
						var Last = InputLine.Substring(0, 11);
						var Pay = double.Parse(InputLine.Substring(31, 5));
						var Hours = int.Parse(InputLine.Substring(16, 2));
						var OverT = int.Parse(InputLine.Substring(29, 1));
						// 
						var Earnings = (Hours * Pay);
						var Gross = Earnings + (OverT * (Pay * 1.5));
						sw.Write(First.PadRight(11)); //Error Code occurs here
						sw.WriteLine(Last.PadRight(11));
						//
						sw.Write(Earnings.ToString().PadLeft(10) + " @ " + Gross.ToString("C").PadRight(9));
						sw.WriteLine(Earnings.ToString("C").PadLeft(17));
						sw.WriteLine();
						//Total += Earnings;
					}
				}
			}
		}
	}
