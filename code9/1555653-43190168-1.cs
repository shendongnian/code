	public static class NameValueExtensionMethods
	{
		/// <summary>
		/// Retrieves a single form variable from the list of
		/// form variables stored
		/// </summary>
		/// <param name="formVars"></param>
		/// <param name="name">formvar to retrieve</param>
		/// <returns>value or string.Empty if not found</returns>
		public static string Form(this  NameValue[] formVars, string name)
		{
			var matches = formVars.Where(nv => nv.name.ToLower() == name.ToLower()).FirstOrDefault();
			if (matches != null)
				return matches.value;
			return string.Empty;
		}
		/// <summary>
		/// Retrieves multiple selection form variables from the list of 
		/// form variables stored.
		/// </summary>
		/// <param name="formVars"></param>
		/// <param name="name">The name of the form var to retrieve</param>
		/// <returns>values as string[] or null if no match is found</returns>
		public static string[] FormMultiple(this  NameValue[] formVars, string name)
		{
			var matches = formVars.Where(nv => nv.name.ToLower() == name.ToLower()).Select(nv => nv.value).ToArray();
			if (matches.Length == 0)
				return null;
			return matches;
		}
	}
