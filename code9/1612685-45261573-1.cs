    @model yournamespace.Models.IdentityUser
    
    @{
        ViewBag.Title = "Details";
    }
    
    <h2>Details</h2>
    <div>
    @foreach (var item in Model)
        {    
            <tr>           
                <td>
                    @Html.DisplayFor(modelItem => item.Email)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Name)
                </td>
    
                    <td>                        
    
                        @Html.ActionLink("Edit |", "UpdateUser", new { id =  item.Id}) 
                        @Html.ActionLink("Details", "Details", new { id =  item.Id}) 
                        @Html.ActionLink("Delete", "Delete", new { id =  item.Id})                      
                   </td>           
            </tr>
        }
    
    </div>
