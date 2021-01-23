    	foreach (var match in
			tokensList.Select(
				word =>
					// Two capturing groups: "word" (unnecessary in your case) and "type", 
					// where "word" contains the word only (e.g. TMConnects) and "type" contains the type only (e.g. MEN).
					Regex.Match(
						word,
						// Match any letters appearing one or more times followed by an opening bracket ('('), anything that 
						// isn't a closing bracket and a closing bracket (')').
						@"^(?<word>[a-z]+)\((?<type>[^\)]+)\)$", 
						// Tell the regular expression engine to ignore the casing.
						RegexOptions.IgnoreCase))
						// Filter out words that don't match the regular expression.
						.Where(match => match.Success)) 
		{
			// The whole word (including the type.
			var word = match.Value;
			// The type lower-cased, for convenience.
			var type = match.Groups["type"].Value.ToLowerInvariant();
			switch (type)
			{
				case "vb":
					Console.WriteLine(word + "v");
					Verbs.Add(word);
					break;
				case "n":
					Console.WriteLine(word + "n");
					Nouns.Add(word);
					break;
				case "adv":
					Console.WriteLine(word + "adv");
					Adverbs.Add(word);
					break;
				case "adj":
					Console.WriteLine(word + "adj");
					Adjectives.Add(word);
					break;
				case "men":
					Console.WriteLine(word + "men");
					Mentions.Add(word);
					break;
				case "knk":
					Console.WriteLine(word + "obj");
					Objects.Add(word);
					break;
				case "kt":
					Console.WriteLine(word + "ft");
					Features.Add(word);
					break;
			}
		}
