    //This is in your project somewhere
    namespace MyNamespace
    {
        public class Product
        {
            public int Id { get; set; }
    
            public int Name { get; set; }
        }
    }
 
    <%-- This is in your ASPX markup (.aspx) --%>
    <ul>
      <asp:Repeater runat="server" id="ProductRepeater" ItemType="MyNamespace.Product">
        <ItemTemplate>
          <li><%#: Item.Id %> - <%#: Item.Name %></li>
        </ItemTemplate>
      </asp:Repeater>
    </ul>     
    //this is in your code behind (.aspx.cs)
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostback)
        {
            List<Product> products = MyDataLayer.GetProducts();
            ProductRepeater.DataSource = products;
            ProductRepeater.DataBind();
        }
    }
