    DateTime currentDay = null;
			foreach (var print in printCM)
            {	
				if(currentDay == null)
				{
					currentDay = print.first.Date;
				}
				else if(currentDay != print.first.Date)
				{
					Console.WriteLine();
					currentDay = print.first.Date;
				}
                Console.Write($"{print.first.ToString("yyyyMMddHHmm")},R0,{print.second},");
            }
