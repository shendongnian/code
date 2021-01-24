    sb.Append("select * from DataTable where "); 
    foreach (Control c in this.Controls) { 
    TextBox t = c as TextBox; 
     if (t != null) { 
      if (t.Length > 0) {
      //In design-time set the TextBox Tag property to the SQL column name
      sb.Append(t.Tag.ToString() + " like '" + t.Text + "%' and ");
       }
      }
     }
    string SQL = sb.ToString();
    if (SQL.Length > 0) {
       SQL = SQL.Substring(0, SQL.Length-5);
    }
    adapt = new SQLiteAdapter(SQL, con); 
    dt = new DataTable(); 
    adapt.Fill(dt); 
    dataGridView1.Source = dt;
