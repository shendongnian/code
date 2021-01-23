    <%@ Page Title="Home Page" Language="C#" %>
    <script language="C#" runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            int width = 0;
            int.TryParse(Request.QueryString["width"], out width);
            var height = 0;
            int.TryParse(Request.QueryString["height"], out height);
            if (width <= 0) width = 100;
            if (height <= 0) height = 100;
            using (var image = new System.Drawing.Bitmap(width, height))
            {
                using (var g = System.Drawing.Graphics.FromImage(image))
                    g.Clear(System.Drawing.Color.Red);
                byte[] buffer =
                (byte[])new System.Drawing.ImageConverter().ConvertTo(image, typeof(byte[]));
                Response.ContentType = "image/bmp";
                Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }
    </script>
