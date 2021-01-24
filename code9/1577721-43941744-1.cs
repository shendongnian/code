    //Here is the ID of the item you want update
    string sampleID = Request.QueryString["si"].ToString();
    using (SqlCommand sc = new SqlCommand(@"Update Sample
         set ConsentConfirmed='NO' , DateConsent='',  ConsentNameID=@NewConsentName
            WHERE  MBID = @MBID and ConsentNameID = @ConsentID and SampleID=@SampleID", con))
                {
                    sc.Parameters.Add("@MBID", SqlDbType.Int).Value=MBID;
                    sc.Parameters.Add("@ConsentID", SqlDbType.Int).Value = ConsentID;
                    sc.Parameters.Add("@NewConsentName", SqlDbType.Int).Value = NewConsentName;
                    int records = sc.ExecuteNonQuery();
                    int value = records;
            //lbSample is the ListBox Control containing the items
                  foreach (ListItem item in lbSample.Items)
                    {
                         //here is looking for each item that hold same value as your same ID.
                        if (item.SelectedValue == sampleID)
                        {
                            try
                            {
                                sc.Parameters["@SampleID"].Value = item.Text;
                                sc.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Label1.Text = ex.Message;
                            }
                        }
                    }
                }
