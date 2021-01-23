            var regexPattern = @"\[QUOTE[=]{0,1}([\d\w;]*)\](.|\r|\n)*\[/QUOTE\]";
			var test1 = @"[QUOTE=Axio;26]
				Test sentence
				[/QUOTE]";
			var test2 = @"[QUOTE]
				Test sentence
				[/QUOTE]";
			var regex = new Regex(regexPattern);
			var match = regex.Match(test1);
			if (match.Success)
			{
				if (match.Groups.Count > 1) //matched [QUOTE=...]
					match.Groups[1].Value.Split(';').ToList().ForEach(s => Console.WriteLine(s));
				else //matched [QUOTE]..
					Console.WriteLine("Matched [QUOTE]");
			}
			else Console.WriteLine("No match"); 
			Console.Read();
