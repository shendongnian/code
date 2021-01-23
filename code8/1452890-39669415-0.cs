        protected void ProductCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var catItem = e.Item.DataItem as Item;
            Repeater categoriesRepeater = e.Item.FindControl("CategoriesRepeater") as Repeater;
            var catProducts = catItem.GetChildren();
            categoriesRepeater.DataSource = catProducts;
            categoriesRepeater.DataBind();
        }
        protected void Categories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var catItem = e.Item.DataItem as Item;
            HyperLink itemLink = e.Item.FindControl("ItemURL") as HyperLink;
      
                if (catItem.Fields["Item No"] != null)
                {
                    itemLink.Text = catItem.Fields["Item No"].ToString() + "<br />";
                }
                else
                {
                    itemLink.Text = catItem.Fields["Menu Title"].ToString() + "<br />";
                }
         }
         <asp:Repeater ID="ProductCategories" runat="server" ItemType="Sitecore.Data.Items.Item" Visible="true" OnItemDataBound="ProductCategories_ItemDataBound">
            <ItemTemplate>
                <div class="left-nav-section clearfix">
                    <div class="left-nav-section-arrow clearfix"></div>
                    <a class="left-nav-sub-section-title" href="<%# Sitecore.Links.LinkManager.GetItemUrl(Item) %>" runat="server">
                        <%# Item.Fields["Menu Title"].Value %>
                    </a>
                    <div class="the-tiers">
                        <asp:Repeater runat="server" ID="CategoriesRepeater" ItemType="Sitecore.Data.Items.Item" OnItemDataBound="Categories_ItemDataBound">
                            <ItemTemplate>
                                <asp:HyperLink ID="ItemURL" CssClass="left-nav-sub-tier" runat="server" NavigateUrl="<%# Sitecore.Links.LinkManager.GetItemUrl(Item) %>"/>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
