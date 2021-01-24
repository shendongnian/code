		protected Expression GetUserRoleExtraConditionExpression(Expression param)
		{
			Expression expression;
			IPrincipal user = HttpContext.Current.User;
			if (user.IsInRole(Consts.Roles.Administrator))
			{
				expression = Expression.Constant(true);
			}
			else if (user.IsInRole(Consts.Roles.Employee))
			{
				int businessUnitId = UserManager.FindById(user.Identity.GetUserId()).BusinessUnitId;
				expression = Expression.Equal(
					Expression.Property(param, "BusinessUnitId"),
					Expression.Constant(businessUnitId));
			}
			else if (user.IsInRole(Consts.Roles.RegisteredUser))
			{
				string userId = user.Identity.GetUserId();
				expression = Expression.Equal(
					Expression.Property(param, "UserId"),
					Expression.Constant(userId));
			}
			else
			{
				expression = Expression.Constant(false);
			}
			return expression;
		}
