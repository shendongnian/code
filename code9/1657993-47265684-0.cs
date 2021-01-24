    @using DotNetNuke.Web.DDRMenu;
    @using System.Dynamic;
    @using DotNetNuke.Entities.Portals;
    @inherits DotNetNuke.Web.Razor.DotNetNukeWebPage<dynamic>
    @{
    	var root = Model.Source.root;
    }
    @helper RenderNodes(IList<MenuNode> nodes)
    {
    	if (nodes.Count > 0)
    	{
    		<ol class="breadcrumb">
    			@foreach (var node in nodes)
    			{
    				foreach (var child in node.Children)
    				{
    					if (child.Text == PortalSettings.Current.ActiveTab.TabName)
    					{
    						if (node.Parent.Children.Count > 0)
    						{
    							@RenderChildNodes(node.Children)
    						}
    					}
    				}
    				if(node.Selected && node.Depth == 0 && node.HasChildren())
    				{
    					@RenderChildNodes(node.Children)
    				}
    			}<!-- ./ for loop -->
    		</ol>
    	}<!-- ./ node count -->
    }<!-- ./ helper -->
    @helper RenderChildNodes(IList<MenuNode> nodes)
    {
    	if (nodes.Count > 0)
    	{
    		foreach (var node in nodes)
    		{
    			string isActive = "";
    			string isDisabled = "";
    			if (node.Selected) { isActive = "active"; }
    			if (!node.Enabled) { isDisabled = "disabled"; }
    			<li class="breadcrumb-item @isActive">
    				<a href="@node.Url" class=" @isDisabled">@node.Text</a>
    			</li>
    		}
    	}
    }
    @RenderNodes(root.Children)
    <script>
    	if ($('.breadcrumb-item').length > 0)
    		$('.breadcrumb').show();
    	else
    		$('.breadcrumb').hide();
    </script>
