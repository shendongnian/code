	// initialize.
	ImmutableDictionary<string, int> dict = ImmutableDictionary.Create<string,int>();
	// create a new dictionary with "foo" key added.
	ImmutableDictionary<string, int> newdict = dict.Add("foo", 0);
	
	// replace dict, thread-safe, with a new dictionary with "bar" added.
	// note this is using dict, not newdict, so there is no "foo" in it.
	ImmutableInterlocked.TryAdd(ref dict, "bar", 1);
	// take a snapshot, thread-safe.
	ImmutableDictionary<string,int> snapshot = dict;
