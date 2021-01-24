	string value = "Filipović with Unicode symbol: ";
    var result = new StringBuilder();		
    for (int i = 0; i < value.Length; i++)
    {
        if (Char.IsHighSurrogate(value[i]))
        {
            result.Append($"&#{Char.ConvertToUtf32(value[i], value[i + 1])};");
            i++;
        }
        else if (value[i] > 127)
		    result.Append($"&#{(int)value[i]};");
		else
			result.Append(value[i]);
	}
		
	Console.WriteLine(result); // Filipovi&#263; with Unicode symbol: &#127983;
