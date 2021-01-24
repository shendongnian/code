        protected void drpdwnYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the data for the specific make/model/year from the database
            DataTable dt = new DataTable();
            string tempYear = drpdwnYear.SelectedItem.ToString();
            string tempManufacturer = Globals.myManufacturer;
            string tempModel = Globals.myModel;
            Globals.myQuery = "SELECT * FROM CrawlerInfo WHERE Model = '" + tempModel + "' AND Year ='" + tempYear + "'";
            try
            {
                using (SqlConnection con = new SqlConnection(Globals.myConStr))
                {
                    using (SqlCommand cmd = new SqlCommand(Globals.myQuery, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                handleTheError(ex);
            }
            //put the data into HTML elements
            try
            {
                int tempflag = 0;
                foreach (DataRow tempRow in dt.Rows)
                {
                    string tempCategory = tempRow[4].ToString();
                    string tempPartUrl = tempRow[5].ToString();
                    string tempImageUrl = tempRow[6].ToString();
                    string tempPartBrand = tempRow[7].ToString();
                    string tempPartName = tempRow[8].ToString();
                    string tempPrice = tempRow[9].ToString();
                    string tempStoreName = tempRow[10].ToString();
                    Image tpImg = new Image();
                    tpImg.ID = "id_img_" + tempflag;
                    tpImg.ImageUrl = tempImageUrl;
                    Page.Controls.Add(tpImg);
                    
                    HyperLink hyp = new HyperLink();
                    hyp.ID = "id_link_" + tempflag;
                    hyp.NavigateUrl = tempPartUrl;
                    hyp.Text = tempPartBrand + " " + tempPartName + ": " + tempPrice + "\n\n";
                    Page.Controls.Add(hyp);
                    tempflag++;
                }
            }
            catch (Exception ex)
            {
                handleTheError(ex);
            }
        }
