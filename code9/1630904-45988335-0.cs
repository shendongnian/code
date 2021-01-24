    	public static void stuff()
		{		
			string name = "bob";
			string firstNumber = "";
			string secondNumber = "";
			int lineIndex = 0;
			
			List<string> lines = new List<string>(File.ReadAllLines(@"C:\Text.txt"));
			
			foreach(string line in lines)
			{
				if(line.Contains(name))
				{
					lineIndex = lines.IndexOf(line);
					string[] parts = line.Split('#');
					name = parts[0];
					firstNumber = parts[1].Split(' ')[0];	
					secondNumber = parts[1].Split(' ')[1];
					
					firstNumber = (Convert.ToInt32(firstNumber) + 1).ToString();
					
					/*
					 * instert code here for changing the number you want to change
					*/
		
					lines[lineIndex] = name + "#" + firstNumber + " " + secondNumber;
					File.WriteAllLines(@"C:\Text.txt",lines.ToArray());
					break;
				}
			}					
		}
