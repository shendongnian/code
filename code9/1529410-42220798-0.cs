    <Triggers>
       <asp:AsyncPostBackTrigger ControlID="Timer1" />
            </Triggers>
        <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="1000"></asp:Timer>
    private void Timer1_Tick(object sender, EventArgs e)
        {
            lblmsg.Text = DateTime.Now.ToString();
            if (DateTime.Now.ToString() == "14-02-2017 11:55:08")
            {
                b4_production_report_excel obj = new b4_production_report_excel();
                int a = obj.insert_comment("2017", "1", "TAB", "Comment", "Admin");
            }
        }
