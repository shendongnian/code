    public partial class MyPage : Page
    {
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            ShowMessage("Hello World!");
        }
    
        public void ShowMessage(string message)
        {
            var script = $@"<script type='text/javascript'>window.onload=function(){{alert('{message}')}};</script>";
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", script);
        }
    }
