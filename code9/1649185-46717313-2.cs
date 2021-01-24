    public static class Utility  
	{
		private static string[] GetDefaultKeyPropertySet(PSObject mshObj)
		{
			PSMemberSet standardNames = mshObj.Members["PSStandardMembers"] as PSMemberSet;
            if (standardNames == null)
            {
                return null;
            }
			PSPropertySet  defaultKeys = standardNames.Members["DefaultKeyPropertySet"] as PSPropertySet;
            if (defaultKeys == null)
            {
                return null;
            }
            string[] props = new string[defaultKeys.ReferencedPropertyNames.Count];
            defaultKeys.ReferencedPropertyNames.CopyTo(props, 0);
            return props;
        }
    }
