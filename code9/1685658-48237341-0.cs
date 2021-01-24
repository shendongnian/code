    <%
       var cpus = productItems.FindAll(t => t.Type == "cpu");
       foreach (var cpu in cpus)
       { %>
    <div class="row product cpu">
       <div class="col-md-3">
          <img class="center-block" src="Content/images/processor.jpg" />
          <span class="price"><%= cpu.Price %></span>
          <span class="addtocart">
             <% Button b = new Button();
                b.ID = "Button" + cpu.ID;
                b.CommandArgument = cpu.ID.ToString();
                b.Text = "Add to Cart";
                b.OnClientClick = "Addtocart_Click";
                placeHolder1.Controls.Add(b);
                %>
             <asp:PlaceHolder ID="placeHolder1" runat="server"></asp:PlaceHolder>
          </span>
          <br />
       </div>
    </div>
    <% } %>
