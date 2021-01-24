	var arrayWords = new[,] { { "daniel", "dany" }, { "ebrid", "ebraham" }, { "orlang", "lang" }, { "edison", "edwaid" } };
    var inputString = "ebrid jackson";
    Stopwatch sw;
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 100000000; x > 0; x--)
    {
        var words = inputString.Split(' ');
        var result = new List<string>();
        foreach (var word in words)
        {
            var found = false;
            for (var index = arrayWords.GetLength(0) - 1; index >= 0; index--)
            {
                if (word != arrayWords[index, 0])
                {
                    continue;
                }
                result.Add(arrayWords[index, 1]);
                found = true;
                break;
            }
            if (!found)
            {
                result.Add(word);
            }
        }
        var str = string.Join(" ", result);
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"array & foreach & List - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
	
    sw = Stopwatch.StartNew();
    for (var x = 100000000; x > 0; x--)
    {
        var words = inputString.Split(' ');
        var result = new List<string>();
        for (int i = 0, wordsLength = words.Length; i < wordsLength; i++)
        {
            var word = words[i];
            var found = false;
            for (var index = arrayWords.GetLength(0) - 1; index >= 0; index--)
            {
                if (word != arrayWords[index, 0])
                {
                    continue;
                }
                result.Add(arrayWords[index, 1]);
                found = true;
                break;
            }
            if (!found)
            {
                result.Add(word);
            }
        }
        var str = string.Join(" ", result);
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"array & for & List - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 100000000; x > 0; x--)
    {
        var words = inputString.Split(' ');
        var result = new StringBuilder();
        var first = true;
        foreach (var word in words)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                result.Append(" ");
            }
            var found = false;
            for (var index = arrayWords.GetLength(0) - 1; index >= 0; index--)
            {
                if (word != arrayWords[index, 0])
                {
                    continue;
                }
                result.Append(arrayWords[index, 1]);
                found = true;
                break;
            }
            if (!found)
            {
                result.Append(word);
            }
        }
        var str = result.ToString();
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"array & foreach & StringBuilder - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 100000000; x > 0; x--)
    {
        var words = inputString.Split(' ');
        var result = new StringBuilder();
        var first = true;
        for (int i = 0, wordsLength = words.Length; i < wordsLength; i++)
        {
            var word = words[i];
            if (first)
            {
                first = false;
            }
            else
            {
                result.Append(" ");
            }
            var found = false;
            for (var index = arrayWords.GetLength(0) - 1; index >= 0; index--)
            {
                if (word != arrayWords[index, 0])
                {
                    continue;
                }
                result.Append(arrayWords[index, 1]);
                found = true;
                break;
            }
            if (!found)
            {
                result.Append(word);
            }
        }
        var str = result.ToString();
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"array & for & StringBuilder - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 100000000; x > 0; x--)
    {
        var str = inputString;
        for (var index = arrayWords.GetLength(0) - 1; index >= 0; index--)
        {
            str = Regex.Replace(str, @"\b" + Regex.Escape(arrayWords[index, 0]) + @"\b", arrayWords[index, 1]);
        }
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"array & Regex - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    // Notice I am not cointing the time to build the Dictionary
    // I decided this because I suppose it is possible you get
    // the input into the Dictionary directly,
    // And if you cannot, then this should be fast anyway
    // Run your own tests if you disagree.
    var dictionary = new Dictionary<string, string>();
    for (var index = 0; index < arrayWords.GetLength(0); index++)
    {
        dictionary[arrayWords[index, 0]] = arrayWords[index, 1];
    }
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 0; x < 100000000; x++)
    {
        var words = inputString.Split(' ');
        var result = new List<string>();
        foreach (var word in words)
        {
            result.Add(dictionary.ContainsKey(word) ? dictionary[word] : word);
        }
        var str = string.Join(" ", result);
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & foreach & List - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 0; x < 100000000; x++)
    {
        var words = inputString.Split(' ');
        var result = new List<string>();
        for (int i = 0, wordsLength = words.Length; i < wordsLength; i++)
        {
            var word = words[i];
            result.Add(dictionary.ContainsKey(word) ? dictionary[word] : word);
        }
        var str = string.Join(" ", result);
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & for & List - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 0; x < 100000000; x++)
    {
        var words = inputString.Split(' ');
        var str = string.Join(" ", words.Select(word => dictionary.ContainsKey(word) ? dictionary[word] : word));
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & Linq - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 0; x < 100000000; x++)
    {
        var words = inputString.Split(' ');
        var result = new StringBuilder();
        var first = true;
        foreach (var word in words)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                result.Append(" ");
            }
            result.Append(dictionary.ContainsKey(word) ? dictionary[word] : word);
        }
        var str = result.ToString();
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & foreach & StringBuilder - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 0; x < 100000000; x++)
    {
        var words = inputString.Split(' ');
        var result = new StringBuilder();
        var first = true;
        for (int i = 0, wordsLength = words.Length; i < wordsLength; i++)
        {
            var word = words[i];
            if (first)
            {
                first = false;
            }
            else
            {
                result.Append(" ");
            }
            result.Append(dictionary.ContainsKey(word) ? dictionary[word] : word);
        }
        var str = result.ToString();
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & for & StringBuilder - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 0; x < 100000000; x++)
    {
        var words = inputString.Split(' ');
        var str = words.Aggregate((StringBuilder: new StringBuilder(), First: true), (result, word) =>
        {
            if (!result.First)
            {
                result.StringBuilder.Append(" ");
            }
            result.StringBuilder.Append(dictionary.ContainsKey(word) ? dictionary[word] : word);
            return (StringBuilder: result.StringBuilder, First: false);
        }).ToString();
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & Linq & StringBuilder - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
		
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 100000000 - 1; x >= 0; x--)
    {
        var str = inputString;
        foreach (var pair in dictionary)
        {
            str = Regex.Replace(str, @"\b" + Regex.Escape(pair.Key) + @"\b", pair.Value);
        }
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & foreach & Regex - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
    sw = Stopwatch.StartNew();
    for (var x = 100000000 - 1; x >= 0; x--)
    {
        var str = dictionary.Aggregate(inputString, (current, pair) => Regex.Replace(current, @"\b" + Regex.Escape(pair.Key) + @"\b", pair.Value));
        GC.KeepAlive(str);
    }
    sw.Stop();
    Console.WriteLine($"Dictionary & Linq & Regex - Time taken: {sw.Elapsed.TotalMilliseconds}ms");
	
	GC.Collect();
	GC.WaitForPendingFinalizers();
    /*----------------------------------*/
