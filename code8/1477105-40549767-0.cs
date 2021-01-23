    string id_new;
    id_new = Session["selectedmusicID"].ToString();
    DataTable dt2 = new DataTable();
    dt2 = blm.selectMusic("sel_music", Convert.ToInt32(id_new));
    string test = dt2.Rows[0][9].ToString();
    string filename = test.Substring(9).Replace(" " , "").Replace(".mp3" , ".MP3");
    byte[] buffer = (byte[])(dt2.Rows[0][10]);
    Response.ContentType = "audio/mpeg";
    Response.AddHeader("Content-Disposition", "Attachment;filename=" + filename);
    byte[] datablock = new byte[0x1000];
    long filesize;
    int bytesread;
    long totalsbytesread = 0;
    using (Stream st = new MemoryStream(buffer))
            {
                filesize = st.Length;
                while (totalsbytesread < filesize)
                {
                    if (Response.IsClientConnected)
                    {
                        bytesread = st.Read(datablock, 0, datablock.Length);
                        Response.OutputStream.Write(datablock, 0, bytesread);
                        Response.Flush();
                        totalsbytesread += bytesread;
                    }
                }
            }
            Response.End();
