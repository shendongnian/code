        SQLiteConnection con = new SQLiteConnection("Data Source=Quran.sqlite;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand("SELECT Qtxt2 FROM tblQTxt where Sore='1' and Aye='1'", con);
        SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(cmd);
        DataSet dSet = new DataSet();
        dAdapter.Fill(dSet);
        if (dSet.Tables[0].Rows.Count == 1)
        {
            Byte[] data = new Byte[0];
            data = (Byte[])(dSet.Tables[0].Rows[0]["Qtxt2"]);
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, data.Length);
            ms.Position = 0;
            StreamReader reader = new StreamReader(ms,Encoding.GetEncoding(1256));
            string text = reader.ReadToEnd();
            textBox1.Text = text;
        }
