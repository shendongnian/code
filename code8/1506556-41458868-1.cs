    <asp:Label ID="Label3" runat="server"  Text="Date not confirm" 
             Visible='<%#GetVisible2(Eval("DateofEvent"))%>'></asp:Label>
        
        public bool GetVisible2(DateTime? value)
        {
            if (value == null || value == DateTime.MinValue)
            {
                return true;
            }
            return false;
        }
