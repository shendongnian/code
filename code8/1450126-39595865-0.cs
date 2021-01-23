    private void button1_Click(object sender, EventArgs e){        
            SqlConnection con = new SqlConnection("Data Source=IBM-PC\\SQLEXPRESS2;Initial Catalog=DBACCESS;Integrated Security=True");
            
            MemoryStream ms = new MemoryStream();
            Bitmap bmp = new Bitmap(cmrConductor.Width, cmrConductor.Height);
            cmrConductor.DrawToBitmap(bmp, cmrConductor.Bounds);
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] Pic_arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(Pic_arr, 0, Pic_arr.Length);
            SqlCommand cmd = new SqlCommand("INSERT INTO tblUsers (fldCode, fldPic) VALUES (@fldCode, @fldPic)", con);
            cmd.Parameters.AddWithValue("@fldCode", txtId.Text);
            cmd.Parameters.AddWithValue("@fldPic", Pic_arr);
            con.Open();
            try
            {
               int res = cmd.ExecuteNonQuery();
               if (res > 0)
               {
                  MessageBox.Show("insert");
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
