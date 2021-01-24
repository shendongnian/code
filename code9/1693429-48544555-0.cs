    foreach (System.Web.UI.WebControls.ListItem item in checkboxtest.Items)
        {
            cm = item.Text;
           sb.Append("<tr>");
            sb.Append("<td><input type=\"text\" name=\"field " + z + "\"></td>");
            sb.Append("</tr>");
            z = z + 1;
        }
       
