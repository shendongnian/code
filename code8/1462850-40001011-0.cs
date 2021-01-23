        <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Button" CommandName="apply code" CommandArgument='<%# Eval("tocht_id") %>' />
                <asp:TextBox ID="itemCoupon" runat="server"></asp:TextBox>
                <asp:Label ID="item_ID" runat="server" Text='<%# Eval("tocht_id") %>'></asp:Label>
            </ItemTemplate>
        </asp:ListView>
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "apply code")
            {
                TextBox coupon = (TextBox)e.Item.FindControl("itemCoupon");
                Label productID = (Label)e.Item.FindControl("item_ID");
                if (!string.IsNullOrEmpty(coupon.Text) & !string.IsNullOrEmpty(productID.Text))
                {
                    //this works
                    Response.Write(coupon.Text + "___" + productID.Text);
                }
            }
        }
