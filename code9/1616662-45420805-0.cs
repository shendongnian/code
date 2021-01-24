    string renderedControl;
    {
        var page = new Page();
        var ctrl = (ResponsiveImageFixedSize)page.LoadControl("~/PageControls/ResponsiveImageFixedSize/ResponsiveImageFixedSize.ascx");
        ctrl.Width = 600;
        ctrl.UploadedImage = upload;
        ctrl.OriginalImagePath = originalImagePath;
        ctrl.Alt = alt;
        page.Controls.Add(ctrl);
        var sw = new StringWriter();
        HttpContext.Current.Server.Execute(page, sw, false);
        renderedControl = sw.ToString();
    }
