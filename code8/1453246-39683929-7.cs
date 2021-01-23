    @foreach(var site in Model.AvailableSites)
    {
        // assumes your using Razor v2 or higher
        bool isSelected = Model.Sites.Contains(s.ID);
        <label>
            <input type="checkbox" name="Sites" value="@site.ID" checked = @isSelected />
            <span>@s.Name</span>
        </label>
    }
    @Html.ValidationMessageFor(m => m.Sites)
