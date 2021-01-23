	public void FunctionA(DbContext context, int openid)
	{
		var member = db.Members.Find(openid);
		member.A=a;
		db.Entry(member).Property("A").IsModified = true;
	}
	public void FunctionB(DbContext context, int openid)
	{
		var member = db.Members.Find(openid);
		member.B=b;
		db.Entry(member).Property("B").IsModified = true;
	}
