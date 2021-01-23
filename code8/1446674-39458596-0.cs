	public static T Cast<T>(this object myobj)
	{
		var target = typeof(T);
		var x = Activator.CreateInstance(target, false);
		var d = from source in target.GetMembers().ToList()
				where source.MemberType == MemberTypes.Property
				select source;
		var memberInfos = d as MemberInfo[] ?? d.ToArray();
		var members = memberInfos.Where(memberInfo => memberInfos.Select(c => c.Name)
		   .ToList().Contains(memberInfo.Name)).ToList();
		foreach (var memberInfo in members)
		{
			var propertyInfo = typeof(T).GetProperty(memberInfo.Name);
			if (myobj.GetType().GetProperty(memberInfo.Name) == null) continue;
			var value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);
			propertyInfo.SetValue(x, value, null);
		}
		return (T)x;
	}
