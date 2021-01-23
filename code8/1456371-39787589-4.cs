    @ {
        object members = new { pageName = @item.Name, pageUrl = @item.Url};
    }
    
    <script>
        var myObj = @Html.RenderAsJson(members); // With HtmlHelper.
        var myObj2 = @Html.Raw(Json.Encode(members)) // Without HtmlHelper.
    </script>
