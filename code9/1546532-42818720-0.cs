     @model DynamicMenuLoading.Models.Menu
      @{
         Layout = null;
       }
      <ul>
        <li>
      @{
        string name = "";
    
        foreach (var item in Model.SubMenuItems)
        {
            if (item.MainMenuName != name)
            {
                name = item.MainMenuName;
                <a href="#">
                    <span>@item.MainMenuName</span>
                </a>
            }
    
    
          <ul>
          <li><a href="@Url.Action(item.ActionName , item.ControllerName )"><i class="fa fa-circle-o"></i>@item.SubMenu</a></li>
    
         </ul>
    
         }
        }
         </li>
      </ul>
