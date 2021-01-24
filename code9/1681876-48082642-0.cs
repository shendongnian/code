	@using Telerik.Sitefinity.UI.MVC
	@using Telerik.Sitefinity.Mvc
	@model SitefinityWebApp.Mvc.Models.BugModel
	<h1>Create a Bug</h1>
	@*@using (Telerik.Sitefinity.UI.MVC.SitefinityExtensions.BeginFormSitefinity(Html, "CreateBug", "BugForm"))*@
	@using (Html.BeginFormSitefinity("CreateBug", "BugForm"))
	{
		@Html.EditorForModel()
		<input type="submit" value="save" />
	}
