    @model IEnumerable<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>
        
        @foreach (var item in Model.Where(u=>{return User.IsInRole("Admin");})
        {
        
            <tr>
                <td class="c">
                    @item.UserName
                </td>
        
                <td class="c">
                    @item.EmailConfirmed
                </td>
            </tr>
        }
