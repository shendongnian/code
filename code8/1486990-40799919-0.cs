        // Sample data
        var items = new string[] { "User1", "User2", "User3" };
        foreach (var item in items)
        {
            // Create a new div control for each item
            // You can create any ASP.NET WebForms control as well, such ASP.Net Label or etc
            System.Web.UI.HtmlControls.HtmlGenericControl divControl = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV") {
                ID = item,
                InnerHtml = item
            };
            // Add control to the page
            // You can also add control to a panel or any container control
            Controls.Add(divControl);
        }
