    public class EnableQueryForGuid : EnableQueryAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			var url = actionContext.Request.RequestUri.OriginalString;
			var newUrl = ModifyUrl(url);
			actionContext.Request.RequestUri = new Uri(newUrl);
			base.OnActionExecuting(actionContext);
		}
		private string ModifyUrl(string url)
		{
			Regex regex = new Regex(@"%27([A-Za-z0-9]{32})%27");
			var res = regex.Matches(url);
			if (res.Count > 0)
			{
				var guidPart = res[0].Value.Remove(0, 3);
				guidPart = guidPart.Remove(guidPart.Length - 3, 3);
				var guidValue = new Guid(BitConverter.ToString((new Guid(guidPart)).ToByteArray()).Replace("-", ""));
				url = url.Replace(res[0].Value, guidValue.ToString());
			}
			return url;
		}
	}
