    .aspx
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="sm" />
    <div>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
        <asp:GridView ID="gvProducts" runat="server" OnPageIndexChanging="gvProducts_PageIndexChanging" AutoGenerateColumns="False" AllowPaging="true" PageSize="5" DataKeyNames="ProductID">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:TemplateField HeaderText="CategoryName" SortExpression="CategoryName">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
    .aspx.vb
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindProds()''//Bind initial
        End If
    End Sub
    Protected Sub gvProducts_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvProducts.PageIndex = e.NewPageIndex
        BindProds()''//Bind when pageIndex changing
    End Sub
    Private Sub BindProds()
        Using cnn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("NorthwindCnn").ConnectionString)
            Using cmd As New Data.SqlClient.SqlCommand("SELECT Products.ProductID, Products.ProductName, Products.CategoryID, Categories.CategoryName FROM Products INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID", cnn)
                Dim da As New Data.SqlClient.SqlDataAdapter(cmd)
                Dim dt As New Data.DataTable()
                da.Fill(dt)
                da.Dispose()
                gvProducts.DataSource = dt
                gvProducts.DataBind()
            End Using
        End Using
    End Sub
