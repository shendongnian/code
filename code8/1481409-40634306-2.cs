			string text = @"some text 1
	some text 2
	some text 3
	some text 2
	some text 5
	some text 6
	some text 2
	some text 7
	some text 2
	some text 9";
			
			string[] lines = text.Split(new string[] { "\n", "\r" }, System.StringSplitOptions.RemoveEmptyEntries);
			List<string> newLines = new List<string>();
			int toRemove = 0;
        	for(int x = 0; x < lines.Length; x++)
			{				
				if(toRemove > 0)
				{
					Console.WriteLine("-" + (x%2==1?"ODD":"EVEN")+ ": " + lines[x]);
					toRemove--;
					continue;
				}
				
				if(x % 2 == 1 && newLines.Contains(lines[x]))
				{
					Console.WriteLine("-" + (x%2==1?"ODD":"EVEN")+ ": " + lines[x]);
					toRemove++;
					continue;
				}
				
				Console.WriteLine("+" + (x%2==1?"ODD":"EVEN")+ ": " + lines[x]);
				newLines.Add(lines[x]);
			}
		}
