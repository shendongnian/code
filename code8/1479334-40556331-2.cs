    <asp:DropDownList ID="AttendStatusAllDropDownList" runat="server">
        <asp:ListItem Value="" Text=""></asp:ListItem>
        <asp:ListItem Value="TM005" Text="Time Missed 005 Min"></asp:ListItem>
        <asp:ListItem Value="TM010" Text="Time Missed 010 Min"></asp:ListItem>
        <asp:ListItem Value="TM015" Text="Time Missed 015 Min"></asp:ListItem>
        <asp:ListItem Value="TM030" Text="Time Missed 030 Min"></asp:ListItem>
        <asp:ListItem Value="TM045" Text="Time Missed 045 Min"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="ApplyToAllButton_Click" />
    <br />
    <br />
    <asp:Repeater ID="AttendanceRepeater" runat="server">
        <ItemTemplate>
            <asp:DropDownList ID="AttendStatusDropDownList" runat="server">
                <asp:ListItem Value="" Text=""></asp:ListItem>
                <asp:ListItem Value="TM005" Text="Time Missed 005 Min"></asp:ListItem>
                <asp:ListItem Value="TM010" Text="Time Missed 010 Min"></asp:ListItem>
                <asp:ListItem Value="TM015" Text="Time Missed 015 Min"></asp:ListItem>
                <asp:ListItem Value="TM030" Text="Time Missed 030 Min"></asp:ListItem>
                <asp:ListItem Value="TM045" Text="Time Missed 045 Min"></asp:ListItem>
            </asp:DropDownList><br />
        </ItemTemplate>
    </asp:Repeater>
