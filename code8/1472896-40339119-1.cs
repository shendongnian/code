    if (e.Row.RowType == DataControlRowType.DataRow)
	{
	    CKEditorControl editor = (CKEditorControl)e.Row.FindControl("Editor");
		editor.BodyClass = "lightYellow";
		editor.ContentsCss = ResolveUrl("~/Content/editor.css");
	}
