    var userDic = new Dictionary<string, string> {
			{"399969178745962506", "One"},
			{"104729417217032192", "Two"}
		};
	var p =  @"<@!?(\d+)>";
	var s = "<@399969178745962506> hello to <@!104729417217032192>";
    Console.WriteLine(
       	Regex.Replace(s, p, m => userDic.ContainsKey(m.Groups[1].Value) ?
       		userDic[m.Groups[1].Value] : m.Value
		)
	); // => One hello to Two
    // Or, if you need to keep <@, <@! and >
	Console.WriteLine(
		Regex.Replace(s, @"(<@!?)(\d+)>", m => userDic.ContainsKey(m.Groups[2].Value) ?
			$"{m.Groups[1].Value}{userDic[m.Groups[2].Value]}>" : m.Value
		)
    ); // => <@One> hello to <@!Two>
