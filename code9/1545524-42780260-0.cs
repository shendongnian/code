    <asp:GridView ShowHeaderWhenEmpty="false" AutoGenerateColumns="true" ID="gridViewForQuery" runat="server">
        
    </asp:GridView>
    <% if ("Grid".Equals(ViewData["DisplayMode"])) {
       gridViewForQuery.DataSource = (ViewData["DT"] as System.Data.DataTable); gridViewForQuery.DataBind();
     }%>
 
