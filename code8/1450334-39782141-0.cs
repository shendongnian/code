    	public override bool Equals(object other)
		{
			var otherKey = other as EntityKey;
			if(otherKey==null) return false;
            if (Identifier is string && otherKey.Identifier is string)
            {
                object thiskeySanitized = ((string)Identifier).ToUpper();
                object thatkeySanitized = ((string)otherKey.Identifier).ToUpper();
                return otherKey.rootEntityName.Equals(rootEntityName) && identifierType.IsEqual(thatkeySanitized, thiskeySanitized, entityMode, factory);
            }
            return
                otherKey.rootEntityName.Equals(rootEntityName)
				&& identifierType.IsEqual(otherKey.Identifier, Identifier, entityMode, factory);
		}
		private int GenerateHashCode()
		{
			int result = 17;
		    object sanitizedIdentifier = (identifier is string) ? ((string) identifier).ToUpper() : identifier;
			unchecked
			{
				result = 37 * result + rootEntityName.GetHashCode();
				result = 37 * result + identifierType.GetHashCode(sanitizedIdentifier, entityMode, factory);
			}
			return result;
		}
