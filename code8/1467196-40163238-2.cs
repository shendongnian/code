    @model UserManageViewModel
    <h2>User Management</h2>
    
    @using (Html.BeginForm("AddUser", "UserManagement", FormMethod.Post))
    {
       int index = 0;
       foreach (var item in Model.users)
       {
           Html.Hidden("item[" + index + "].Code", item.Code);
           Html.TextBox("item[" + index + "].Name", item.Name);
           index++;
       }
       <input type="submit" value="Add User" />
    }
