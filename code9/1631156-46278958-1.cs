    private void EggrafesTimologionEsodon_Load(object sender, EventArgs e)
            {
    
                //CmbBoxPelatis.SelectedIndex = -1;
    
                //EggrafesTimologionEsodon values = new EggrafesTimologionEsodon();
                try
                {
    
                    con = new SqlConnection();
                con = DBAccess.Conn;
                con.Open();
    
                adap = new SqlDataAdapter("select ProionParastatikou.* from ProionParastatikou inner join Parastatiko on ProionParastatikou.ParastatikoID = Parastatiko.ParastatikoID" +
                                          " where ProionParastatikou.Ypoloipo > 0.00  and Parastatiko.Eponimia = '" + txtPelatisId.Text + "'", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "BsProionParastatikouEsodon");
                dataGridViewEggrafesProionParastikouEsodon.DataSource = ds.Tables[0];
                
                con.Close();
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
                finally
                {
                    if (MyConn.State != ConnectionState.Closed)
                        MyConn.Close();
                }
            }
