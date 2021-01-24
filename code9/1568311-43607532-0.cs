     public void functionForSelectedValue(int id)
    {
        using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Molecular"].ConnectionString))
        {
            con.Open();
            using (SqlCommand st = new SqlCommand(@"SELECT    * 
                             FROM       Sample
                             WHERE
                             SampleID=@SampleID", con))
            {
                st.Parameters.AddWithValue("@SampleID", id);
                using (SqlDataReader reader = st.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtUpdateSampleID.Text = reader["SampleID"].ToString();
                        txtUpdateSampleType.Text = reader["SampleType"].ToString();
                        txtUpdateSampleDate.Text = reader["SampleDate"].ToString();
                        txtUpdateSampleTrial.Text = reader["SampleTrial"].ToString();
                        DropDownListUpdateFirstSample.SelectedItem.Value = reader["FirstSample"].ToString();
                        txtUpdateSampleComments.Text = reader["Comments"].ToString();
                        txtUpdateSampleConsultant.Text = reader["ConsultantName"].ToString();
                        DropDownListUpdate.SelectedItem.Value = reader["Diagnosis"].ToString();
                        DropDownListUpdateConsentConfirm.SelectedItem.Value = reader["ConsentConfirmed"].ToString();
                        txtUpdateConsentDate.Text = reader["DateConsent"].ToString();
                        txtUpdateOrther.Text = reader["OtherConsent"].ToString();
                        DropDownListUpdateSectionDecline.SelectedItem.Value = reader["SectionDecline"].ToString();
                        DropDownListUpdateQuarantine.SelectedItem.Value = reader["Quarantine"].ToString();
                        DropDownListUpdateClinicalArchive.SelectedItem.Value = reader["ClinicalArchive"].ToString();
                        DropDownListUpdateResearch.SelectedItem.Value = reader["Research"].ToString();
                        //DropDownListUpdateClinicalArchive.SelectedItem.Value= reader["Research"].ToString();
                    }
                }
            }
            con.Close();
        }
    }
    protected void DropDownListUpdateSample_SelectedIndexChanged(object sender, EventArgs e)
    {
        functionForSelectedValue(DropDownListUpdateSample.SelectedItem.Value);
    }
