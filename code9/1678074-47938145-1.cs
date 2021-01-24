    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(@"$(function () {");
        sb.Append(@"var d2 = [[0, 3], [4, 8], [8, 5], [9, 13]];");
        sb.Append(@"$.plot(\""#placeholder\"", [d2]);");
        sb.Append(@"});");
        sb.Append(@"</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangeChart", sb.ToString(), false);
