     Const string DB_CONN_STR = "SERVER=127.0.0.1; DATABASE=test7100; UID=root; PASSWORD=";
    
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
    
            string sqlCmd = "SELECT  `PR4`, `DHT`, `DHR` FROM `table 4` WHERE 1";
                // PR4= place et DHT= time
                MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(dt);
    
    
    
            string[] x = new string[dt.Rows.Count];
            string[] y = new string[dt.Rows.Count];
            string[] z= new string[dt.Rows.Count]
    
    
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                y[i] = dt.Rows[i][0].ToString(); // place
                x[i] = dt.Rows[i][1].ToString(); //  theoretical hour format : "hh:mm:ss"
                z[i] = dt.Rows[i][1].ToString(); //  real hour format : "hh:mm:ss" 
    
            }
    int j= dt.rows.count //j=33
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grapheSillon.Series["théorique"].Points.AddXY(x[i], j);
                grapheSillon.Series["réel"].Points.AddXY(z[i], j);
                j=j-1
            }
