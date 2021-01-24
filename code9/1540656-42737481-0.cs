	if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Equals("en")) {
		return;
	}
	ResourceSet defaultResourceSet = Strings.ResourceManager.GetResourceSet(CultureInfo.GetCultureInfo("en-US"), true, true);
	if (defaultResourceSet == null) {
		return;
	}
	HashSet<DictionaryEntry> defaultStringObjects = new HashSet<DictionaryEntry>(defaultResourceSet.Cast<DictionaryEntry>());
	if (defaultStringObjects.Count == 0) {
		return;
	}
	ResourceSet currentResourceSet = Strings.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
	if (currentResourceSet == null) {
		return;
	}
	HashSet<DictionaryEntry> currentStringObjects = new HashSet<DictionaryEntry>(currentResourceSet.Cast<DictionaryEntry>());
	if (currentStringObjects.Count >= defaultStringObjects.Count) {
		// Either we have 100% finished translation, or we're missing it entirely and using en-US
		HashSet<DictionaryEntry> testStringObjects = new HashSet<DictionaryEntry>(currentStringObjects);
		testStringObjects.ExceptWith(defaultStringObjects);
		// If we got 0 as final result, this is the missing language
		// Otherwise it's just a small amount of strings that happen to be the same
		if (testStringObjects.Count == 0) {
			currentStringObjects = testStringObjects;
		}
	}
	if (currentStringObjects.Count < defaultStringObjects.Count) {
		float translationCompleteness = currentStringObjects.Count / (float) defaultStringObjects.Count;
		Console.WriteLine("Do something with translation completeness: " + translationCompleteness);
	}
