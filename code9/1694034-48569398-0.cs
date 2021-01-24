    string avaterPath=@"D:\Images\NoImage.png";
    string query= "SELECT a.id as id1,a.id2, a.system_id, CONCAT(b.path,a.image) as photo ,b.id as id5,b.name,b.path  FROM users a INNER JOIN systems b ON a.system_id=b.id  order by a.id DESC LIMIT 20";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    var dt = new System.Data.DataTable();
                    da.Fill(dt);
                    bindingSource1.DataSource = dt.Rows.Cast<DataRow>().Select(p => new aclass() { id = (p["id1"].ToString()),  Photo=File.Exists(p["photo enter code here"].ToString())? Image.FromFile(p["photo enter code here"].ToString()):Image.FromFile(avaterPath) }).ToList();
                    conn.Close();
                    
                }
 
