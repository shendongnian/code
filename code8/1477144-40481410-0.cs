    public void ddlCategorySearch_SelectedIndexChanged(object sender, Eventargs e){
    var param = ddlCategorySearch.SelectedValue;
    foreach (var item in myList)//assuming you put the elements you want inside DDL in a list
    if(item.ID == param)
    ddlSubCategorySearch.Items.Add(new ListItem { Text="",Value=""}); //assign DDL elements here such as item.property
    }
    }
