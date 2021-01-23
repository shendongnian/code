    // ***********************************************************************
	public static class MyWebPageExtensions
	{
		public static string GetPostBackControlUniqueID(this Page page)
		{
			if (!page.IsPostBack)
				return string.Empty;
			Control control = null;
			string controlName = page.Request.Params["__EVENTTARGET"]; //this method works only for link buttons which use javascript: __doPostBack(...) and not input type=submit buttons. Note: it is also available in Request.Form collection but this doesn't require to loop over Form.
			if (!String.IsNullOrEmpty(controlName))
			{
				control = page.FindControl(controlName);
			}
			else
			{
				// __EVENTTARGET is null, the control is a button (not javascript linkButton), we need to iterate over the form collection to find it
				foreach (string id in page.Request.Form)
				{
					// handle ImageButton they having an additional "quasi-property" in their Id which identifies mouse x and y coordinates
					if (id.EndsWith(".x") || id.EndsWith(".y"))
					{
						string id2 = id.Substring(0, id.Length - 2);
						control = page.FindControl(id2);
					}
					else
					{
						control = page.FindControl(id);
					}
					if (control is IButtonControl) break;
				}
			}
			return control == null ? String.Empty : control.UniqueID;
		}
	}
