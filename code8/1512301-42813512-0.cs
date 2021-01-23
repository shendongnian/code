    	public MWStructArray Convert(ResolutionContext context)
		{
			var dictionary = context.SourceValue as Dictionary<string, object>;
			var mwStructArray = new MWStructArray(1, 1, dictionary.Keys.ToArray());
			foreach (KeyValuePair<string, object> entry in dictionary)
			{
				if (entry.Value is IDictionary)
				{
					mwStructArray[entry.Key, 1] = context.Engine.Map<MWStructArray>(entry.Value);
				}
				else
				{
					mwStructArray[entry.Key, 1] = entry.Value.ToString();
				}
			}
			return mwStructArray;
		}
