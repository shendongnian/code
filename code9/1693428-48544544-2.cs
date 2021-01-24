        protected void btnBullDozer_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder(string.Empty);
        var columnname = string.Empty;
            sb.Append("<table>");
            sb.Append("<tr>");
        foreach (System.Web.UI.WebControls.ListItem item in checkboxtest.Items)
        {
            columnname = item.Text;
    
            sb.Append("<th>Sponsor Level</th>");
            sb.Append("<th>" + item.Selected + "</th>");
        }
        sb.Append("</tr>");
        var cm = string.Empty;
        int z = 1;
            sb.Append("<tr>");
        foreach (System.Web.UI.WebControls.ListItem item in checkboxtest.Items)
        {
            cm = item.Text;
            sb.Append("<td colspan="2"><input type=\"text\" name=\"field " + z + "\"></td>");
            z = z + 1;
        }
        sb.Append("</tr>");
        sb.Append("</table>");
    
        mask.InnerHtml = sb.ToString();
    }
