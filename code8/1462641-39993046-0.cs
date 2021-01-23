    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
      </ContentTemplate>
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
      </Triggers>
    </asp:UpdatePanel>
