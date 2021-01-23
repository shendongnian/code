    <asp:TemplateField>
        <ItemTemplate>
           <asp:Image ID="imgStatus" runat="server" CssClass="label" ImageURL='<%# GetImage((object)Eval("NBFCTagID")) %>' />
        </ItemTemplate>
    </asp:TemplateField>
         
        
        
     public static string GetImage(object value)
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
