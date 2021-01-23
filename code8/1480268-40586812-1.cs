	public static class MemberInfoGetting {
		public static string GetMemberName<T>(Expression<Func<T>> memberExpression) {
			MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
			var str = expressionBody.ToString();
			var lst =  str.Split('.').Skip(2).ToList();	//This needs LINQ, otherwise do it manually
			StringBuilder retVal = new StringBuilder();
			for (int i = 0; i < lst.Count; i++) {
				retVal.Append(lst[i]);
				if(i != lst.Count -1) {
					retVal.Append(".");
				}
			}				
			return retVal.ToString();
		}
	}
