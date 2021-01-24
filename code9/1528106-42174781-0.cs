        protected void submitt_Click(object sender, EventArgs e)
        {
            try
            {   con.Open();
                SqlCommand command = new SqlCommand("insert into [Students] values ('" + ID.Text + "','" + FN.Text + "', '" + LN.Text + "', '" + Country1.Text + "', '" + gender.SelectedValue + "',  '" + email.Text + "', '" + passportNo.Text + "', '" + PlaceOfIssue.Text + "', '" + issue.Text + "',  '" + Expiry.Text + "', '" + VisaNo.Text + "', '" + VisaExpiry.Text + "', '" + EmiratesNo.Text + "', '" + EmiaratesExpiry.Text + "');", con);
                command.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Uploaded Successfully"; 
            }
            catch (Exception ex)
            {
                Label2.Text = "Same data cannot be submitted again"; 
            }    
        }
    }
