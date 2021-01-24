    <asp:TemplateField HeaderText="Image">
        <ItemTemplate>
            <asp:Image ID="Image1" 
                ImageUrl='<%# "~/ImageHandler.ashx?id=" + Eval("Id") %>'
                runat="server" />                                                           
        </ItemTemplate>
    </asp:TemplateField>
    public class ImageHandler : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request.QueryString["id"];    
            // Retrieve the image data as byte array from database based on the id    
            context.Response.BinaryWrite(YourImageByte);
        }
    
        public bool IsReusable { get{ return false; }}
    }
    
