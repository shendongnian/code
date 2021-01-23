    @{
        List<MisNew.Web.EntityModel.Menu> menuList = ViewBag.Menu;
    
    }
    <ul class="menu page-sidebar-menu  page-header-fixed page-sidebar-menu-hover-submenu " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">
    
        @foreach (var mp in menuList.Where(p => p.ParentId == null))
        {
    
            <li class="@mp.ListCss">
                <a href="#" class="@mp.HyperLinkCss">
                    <i class="@mp.IconCss"></i>
                    <span class="title">@mp.Name</span>
                    <span class="arrow"></span>
                </a>
                @if (menuList.Count(p => p.ParentId == mp.Id) > 0)
                {
                    @:<ul class="sub-menu">
            }
    
                @RenderMenuItem(menuList, mp)
    
                @if (menuList.Count(p => p.ParentId == mp.Id) > 0)
                {
                    @:</ul>
            }
    
            </li>
        }
    </ul>
    
    
    @helper RenderMenuItem(List<MisNew.Web.EntityModel.Menu> menuList, MisNew.Web.EntityModel.Menu mi)
    {
    foreach (var cp in menuList.Where(p => p.ParentId == mi.Id))
    {
    
    
            @:<li class="@cp.ListCss">
        <a href="~/@cp.Url">
            <i class="@cp.IconCss"></i>
            <span class="title">@cp.Name</span>
            <span class="arrow"></span>
        </a>
    
        if (menuList.Count(p => p.ParentId == cp.Id) > 0)
        {
                @:<ul class="sub-menu">
            }
    
            @RenderMenuItem(menuList, cp)
        if (menuList.Count(p => p.ParentId == cp.Id) > 0)
        {
                @:</ul>
          }
        else
        {
                @:</li>
          }
        }
    }
