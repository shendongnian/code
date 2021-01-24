    <asp:Repeater ID="rptDate" runat="server" ItemType="WebApplication1.MyViewModel" SelectMethod="GetData">
        <ItemTemplate>
            <br/>
            Start Date: <%# Item.Start_Date %>
            <asp:Repeater runat="server" ID="rptJob" ItemType="WebApplication1.MyJobsView" DataSource="<%# Item.Jobs %>">
                <ItemTemplate>
                    <br/>Job Title: <%# Item.Job_Title %>
                    <asp:Repeater runat="server" ID="rptJob" ItemType="WebApplication1.MyData" DataSource="<%# Item.Datas %>">
                        <ItemTemplate>
                            Name: <%# Item.Employee_Name %>
                            Start: <%# Item.Start_Time %>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
