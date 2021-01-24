    conn = new MySqlConnection("server=" + hostname + ";uid=" + username + ";pwd=" + password + ";database=databaseimage;Charset=latin1;");
                conn.Open();
                FileStream fs;
                Byte[] bindata;
                MySqlParameter picpara;
                cmd = new MySqlCommand("INSERT INTO mypic (pic) VALUES(?pic)", conn);
                picpara = cmd.Parameters.Add("?pic", MySqlDbType.MediumBlob);
                cmd.Prepare();
    //txtPicPath is the path of the image, e.g. C:\MyPic.png
                fs = new FileStream(txtPicPath.Text, FileMode.Open, FileAccess.Read);
                bindata = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(bindata, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                picpara.Value = bindata;
                cmd.ExecuteNonQuery();
