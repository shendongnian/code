    <asp:TemplateField>
        <ItemTemplate>
           <asp:Image ID="imgStatus" runat="server" CssClass="label" ImageURL='<%# GetImage((int)Eval("NBFCTagID")) %>' />
        </ItemTemplate>
    </asp:TemplateField>
         
        
        
     public static string GetImage(int value)
        {
            if (value != null)
            { 
                return "../Images/green_mark.jpg";
            }
            else
            {
                return "../Images/red_mark.jpg";
            }
        }
