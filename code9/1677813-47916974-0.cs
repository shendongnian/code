	public class CustomChromeClient : WebChromeClient
	{
		public override void OnPermissionRequest(PermissionRequest request)
		{
			request.Grant(request.GetResources());
		}
	}
