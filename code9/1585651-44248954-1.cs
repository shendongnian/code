    <% @Import Namespace="System.Resources" %>
    <% @Import Namespace="System.Globalization" %>
    <% @Import Namespace="System.Threading" %>
    <script runat=server>
        protected override void InitializeCulture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.QueryString["language"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Request.QueryString["language"].ToString());
            base.InitializeCulture();
        }
    </script>
