	public static class ExtensionHelper {
		public static string UserIdentity(this HttpContext context)
		{
			return context.User.Identity.Name.Split('\\')[1].Replace(".", " ");
		}
	}
