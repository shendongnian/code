    protected void gvMembers_ItemDataBound(object sender, GridItemEventArgs e)
        {
            
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                var roles = (from c in DbContext.roles
                             select new { c.Role1, c.RoleID }).ToList();
                GridEditableItem item = e.Item as GridEditableItem;
                // access/modify the edit item template settings here
                DropDownList list = item.FindControl("List1") as DropDownList;
                list.DataSource = roles;
                list.DataBind();
            }
            
        }
