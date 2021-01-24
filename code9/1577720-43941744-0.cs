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
            
                  foreach (ListItem item in lbSample.Items)
                    {
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
