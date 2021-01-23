    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("email") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //loop all the rows in the gridview
        foreach (GridViewRow row in GridView1.Rows)
        {
            //find the checkbox with findcontrol and cast it back to one
            CheckBox checkbox = row.FindControl("CheckBox1") as CheckBox;
    
            //is it checked?
            if (checkbox.Checked == true)
            {
                //do the same for the label with the email address
                Literal literal = row.FindControl("Literal1") as Literal;
    
                string email = literal.Text;
    
                //send email
            }
        }
    }
