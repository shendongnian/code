	[SecurityCritical]
	private void PerformSecurityCheck(Type owner, ref StackCrawlMark stackMark, bool skipVisibility)
	{
		if (owner == null)
			throw new ArgumentNullException("owner");
		RuntimeType underlyingSystemType = owner as RuntimeType;
		if (underlyingSystemType == null)
			underlyingSystemType = owner.UnderlyingSystemType as RuntimeType;
		if (underlyingSystemType == null)
			throw new ArgumentNullException("owner", Environment.GetResourceString("Argument_MustBeRuntimeType"));
		RuntimeType callerType = RuntimeMethodHandle.GetCallerType(ref stackMark);
		if (skipVisibility)
			new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
		else if (callerType != underlyingSystemType)
			new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
		this.m_creatorAssembly = callerType.GetRuntimeAssembly();
		if (underlyingSystemType.Assembly != this.m_creatorAssembly)
			CodeAccessSecurityEngine.ReflectionTargetDemandHelper(PermissionType.SecurityControlEvidence, owner.Assembly.PermissionSet);
	}
