    protected void btnBullDozer_Click(object sender, EventArgs e)
    {
    StringBuilder sb = new StringBuilder(string.Empty);
    var columnname = string.Empty;
    sb.Append("<table>");
    sb.Append("<tr>");
    sb.Append("<th>Sponsor Level</th>");
    foreach (System.Web.UI.WebControls.ListItem item in checkboxtest.Items)
    {
        //This loop will genrate a horizontal header for all checkbox items
        columnname = item.Text;        
        sb.Append("<th>" + item.Selected + "</th>");
    }
    sb.Append("</tr>"); //empty td for Sponsor Level header
    
    var cm = string.Empty;
    int z = 1;
    sb.Append("<tr><td></td>");
    foreach (System.Web.UI.WebControls.ListItem item in checkboxtest.Items)
    {
        //This will generate a item under each header
        cm = item.Text;
        sb.Append("<td><input type=\"text\" name=\"field " + z + "\"></td>");
        z = z + 1;
    }
    sb.Append("</tr>");
    sb.Append("</table>");
    mask.InnerHtml = sb.ToString();
