			Console.Write(" 2. Enter student Name: ");
			string name = Console.ReadLine();
	
			Console.Write(" 3. Enter student Job Title: ");
			string jobTitle = Console.ReadLine();
	
			int yrsOfService = -1;
			do
			{
				Console.Write(" 4. Enter student years of service: ");
			} while (!int.TryParse(Console.ReadLine(), out yrsOfService));
	
			decimal salary = -1m;
			do
			{
				Console.Write(" 4. Enter salary: ");
			} while (!decimal.TryParse(Console.ReadLine(), out salary));
	
			yield return new Student(name, jobTitle, yrsOfService, salary);
	
			Console.WriteLine("Do you want to add another Student? y/n");
			if (Console.ReadLine() == "n")
			{
				yield break;
			}
		}
	}
