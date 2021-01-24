	public class PropertyNameMapContractResolver : DefaultContractResolver
	{
		private Dictionary<string, string> propertyNameMap;
		public PropertyNameMapContractResolver(Dictionary<string, string> propertyNameMap)
		{
			this.propertyNameMap = propertyNameMap;
		}
		protected override string ResolvePropertyName(string propertyName)
		{
			if (this.propertyNameMap.TryGetValue(propertyName, out string resolvedName))
				return resolvedName;
			return base.ResolvePropertyName(propertyName);
		}
	}
