    @model UsrViewModel
    @using (Html.BeginForm())
    {
        <table>
            <thead>....</thead>
            <tbody id="users">
                @foreach (var user in Model.SysUser)
                {
                    @Html.Partial("_User", user)
                }
            </tbody>
        </table>
        <input type="submit" value="save" />
    }
