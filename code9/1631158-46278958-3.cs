    public List<Int64> listToFill;
    
            public void AfterProsthikiProionParastatikou(object sender, EventArgs e, IList<Int64> lst)//object sender,EventArgs e,
            {
                String csvLst = string.Empty;
                int count = 0;
                foreach ( Int64 lstItems in lst)
                {
                    if (count == 0)
                    {
                        csvLst = lstItems.ToString();
                        count += 1;
                    }
                    else
                    {
                        csvLst = csvLst + "," + lstItems.ToString();
                    }
    
                }
                _con = new SqlConnection();
                _con = DBAccess.Conn;
                _con.Open();
                
    
                adap = new SqlDataAdapter("select ProionParastatikou.* from ProionParastatikou where" +
                                                         " ProionParastatikou.Ypoloipo > 0.00  and ProionParastatikou.ProionParastatikouID"+
                                                         " in( " + csvLst + ")", _con);
                
                DataSetApodeixeisTimologiouEsodon ds = new DataSetApodeixeisTimologiouEsodon();
    
                adap.Fill(ds.ApodeixeisProionParastatiko);//
                
                bsProionApodeixeisTimologiouEsodon.DataSource = ds.ApodeixeisProionParastatiko;// Tables[0];
                dataGridViewProionApodeixeisTimologiouEsodon.DataSource = bsProionApodeixeisTimologiouEsodon;
                
                _con.Close();
                
            }
    private void LinkLblEisagogiEggrafon_Click(object sender, EventArgs e)
            {
                if (cmbBoxEponimiaPelatiApodeixeisTimologiouEsodon.Text == "")
                {
                    MessageBox.Show("Πρέπει να επιλέξετε Πελάτη", "Προειδοποίηση");
                }
                else
                {
    
                    EggrafesTimologionEsodon eggrTimolEsodon = new EggrafesTimologionEsodon(cmbBoxEponimiaPelatiApodeixeisTimologiouEsodon.Text);//p
                    
                    eggrTimolEsodon.ShowDialog();
    
                    listToFill = eggrTimolEsodon.lst2send;
    
                    AfterProsthikiProionParastatikou(null,null,listToFill);
                    
                    //AfterProsthikiProionParastatikou(null);
                    //this.Refresh();
                    
                }
    
    
            }
