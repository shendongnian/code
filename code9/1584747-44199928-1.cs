    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script language='javascript'>");
        sb.Append(@"$('#myModal').modal('show');");
        sb.Append(@"</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString());
    }
