	// Try to find OID info within a specific group, and if that doesn't work fall back to all
	// groups for compatibility with previous frameworks
	internal static string FindOidInfoWithFallback(uint key, string value, OidGroup group)
	{
		string info = FindOidInfo(key, value, group);
		// If we couldn't find it in the requested group, then try again in all groups
		if (info == null && group != OidGroup.All)
		{
			info = FindOidInfo(key, value, OidGroup.All);
		}
		return info;
	}
