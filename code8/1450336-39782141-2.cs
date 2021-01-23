    	public CacheKey(object id, IType type, string entityOrRoleName, EntityMode entityMode, ISessionFactoryImplementor factory)
		{
			key = id;
			this.type = type;
			this.entityOrRoleName = entityOrRoleName;
			this.entityMode = entityMode;
            object sanitizedIdentifier = (key is string) ? ((string)key).ToUpper() : key;
            hashCode = type.GetHashCode(sanitizedIdentifier, entityMode, factory);
		}
		public override bool Equals(object obj)
		{
			CacheKey that = obj as CacheKey;
			if (that == null) return false;
            if (key is string && that.key is string)
            {
                object thiskeySanitized = ((string)key).ToUpper();
                object thatkeySanitized = ((string)that.key).ToUpper();
                return entityOrRoleName.Equals(that.entityOrRoleName) && type.IsEqual(thiskeySanitized, thatkeySanitized, entityMode);
            }
            return entityOrRoleName.Equals(that.entityOrRoleName) && type.IsEqual(key, that.key, entityMode);
		}
