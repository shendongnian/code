    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
        </ContentTemplate>
            <asp:Button ID="ButtonSave" runat="server" Text="Save" 
                OnClick="ButtonSave_Click" />
        </ContentTemplate>
        <Triggers>   
            <asp:AsyncPostBackTrigger ControlID="ButtonSave" 
                EventName="Click" />
         </Triggers>
    </asp:UpdatePanel>
