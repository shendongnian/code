            try
            {
                tes.Open();
                //Retrieve BLOB from database into DataSet.
                Com = new SqlCommand();
                Com.Connection = tes;
                Com.CommandText = ("select gambar from tblBARANG where no=@no");
                Com.Parameters.AddWithValue("@no", Convert.ToInt32(txtCARI.Text));
                var da = new SqlDataAdapter(Com);
                var ds = new DataSet();
                da.Fill(ds, "tblBARANG");
                int count = ds.Tables["tblBARANG"].Rows.Count;
                if (count > 0)
                {
                    var data = (Byte[])(ds.Tables["tblBARANG"].Rows[count - 1]["gambar"]);
                    var stream = new MemoryStream(data);
                    pboxGAMBAR.Image = Image.FromStream(stream);
                } 
                tes.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
