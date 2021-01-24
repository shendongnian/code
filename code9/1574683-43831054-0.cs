    sb.Append("select * from DataTable where "); 
    for(int i =0; i < 3; i++) {
    TextBox txt = ((TextBox)this.Controls["textBox" + i.ToString()])
    if (txt.Length > 0) {
      sb.Append("data" + i.ToString() + " like '" + txt.Text + "%' and ");
      }
    }
    
    string SQL = sb.ToString();
    if (SQL.Length > 0) {
       SQL = SQL.Substring(0, SQL.Length-5);
    }
