    @if (Session["UserId"] == null)
    {
        @Styles.Render("~/Content/css");
    }
    else
    {
        @Styles.Render(string.Format("~/Content/{0}", "Darkcss"));
    }
