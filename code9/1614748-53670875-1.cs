    // injected via dependency injection
    ILookupNormalizer keyNormalizer; 
	public virtual string NormalizeKey(string key)
	{
		return (KeyNormalizer == null) ? key : KeyNormalizer.Normalize(key);
	}
