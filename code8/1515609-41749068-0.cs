      try
        {
            SqlCommand cmdSelect=new SqlCommand("select Picture" + 
                  " from tblImgData where ID=@ID",this.sqlConnection1);
            cmdSelect.Parameters.Add("@ID",SqlDbType.Int,4);
            cmdSelect.Parameters["@ID"].Value=this.editID.Text;
    
            this.sqlConnection1.Open();
            byte[] barrImg=(byte[])cmdSelect.ExecuteScalar();
            string strfn=Convert.ToString(DateTime.Now.ToFileTime());
            FileStream fs=new FileStream(strfn, 
                              FileMode.CreateNew, FileAccess.Write);
            fs.Write(barrImg,0,barrImg.Length);
            fs.Flush();
            fs.Close();
            pictureBox1.Image=Image.FromFile(strfn);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            this.sqlConnection1.Close();
        }
