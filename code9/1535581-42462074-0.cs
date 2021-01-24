    private void btn_upd_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(Constr);
            con.Open();
            string myquery = "Select Reg,Rank,Trade,Name,Wing,Father_name,Dob,Gender,Cast,Sect,Serial,Qualification,Tehseel,District,Cnic_No,Blood_Group,Height,Weight,Identification_Mark,Permanent_Add,Nameof_Spouse,Relation,Nameof_MaleKids,image1 from PersonalInfo where Reg='" + txt_srch.Text + "'";
    
            SqlCommand c = new SqlCommand(myquery, con);
    
            SqlDataReader rd = c.ExecuteReader();
            con.Close();
            if (!(rd.HasRows))
            {
                MessageBox.Show("No such data to delete");
            }
            else
            {
                con.Open();
                string query;
    
                query = "update PersonalInfo set Rank='" + textBox2.Text + "', Serial='" + SN.Text + "', Trade='" + textBox3.Text + "',Name='" + textBox4.Text + "',Wing='" + textBox5.Text + "',Father_name='" + textBox6.Text + "',Dob='" + textBox7.Text + "',Gender='" + textBox8.Text + "',Cast='" + textBox9.Text + "',Sect='" + textBox23.Text + "',Qualification='" + textBox10.Text + "',Tehseel='" + textBox24.Text + "',District='" + textBox21.Text + "',Cnic_No='" + textBox11.Text + "',Blood_Group='" + textBox12.Text + "',Height='" + textBox13.Text + "',Weight='" + textBox14.Text + "',Identification_Mark='" + textBox15.Text + "',Permanent_Add='" + textBox16.Text + "',Nameof_Spouse='" + textBox18.Text + "',Relation='" + textBox19.Text + "',Nameof_MaleKids='" + textBox20.Text + "',image1='" + ImageToBase64(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg) + "' where Reg='" + txt_srch.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Updated");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
