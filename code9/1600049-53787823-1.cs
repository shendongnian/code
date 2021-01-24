    public string GetCartId(HttpContext context)
	{
	    if (context.Session.GetString(CartSessionKey) == null)
		{
			if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
			{
				context.Session.SetString(CartSessionKey, context.User.Identity.Name);
			}
			else
			{
				var tempCartId = Guid.NewGuid();
				context.Session.SetString(CartSessionKey, tempCartId.ToString());
			}
		}
		return context.Session.GetString(CartSessionKey);
	}
