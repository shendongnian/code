     protected void onclickregiPatient(object sender, EventArgs e)
        {
            con = new SqlConnection(conString);
            con.Open();
            if (FileUploadControl.HasFile)
            {
                string Name = txtName.Text;
                string surname = txtSurname.Text;
                string gender = genderRadio.Text;
                string dob = txtDob.Text;
                string dop = txtPob.Text;
                string nationality = txtNationality.Text;
                string birthcert = txtBirthCert.Text;
                string nationalid = txtNationalID.Text;
                string occupation = txtOccupation.Text;
                byte[] photo = FileUploadControl.FileBytes;
                string blood = DropDownList1.Text;
                string eye = eyeColor.Text;
                string skin = txtSkinColr.Text;
                string height = txtHeight.Text;
                string status = txtHivstatus.Text;
                string phone = txtPhone.Text;
                string posaddress = txtPosAddress.Text;
                string physicaladdress = txtPhyAddress.Text;
                string fullname = txtFullName.Text;
                string relationship = txtRelationship.Text;
                string phoneno = txtphoneNo.Text;
                string postal = postalAddres.Text;
                string physical = physicalAddress.Text;
                string radio = RadioButtonList1.Text;
                string type = txtType.Text;
                string insertSQL = ("insert into patientProfile values(@Name,@surname,@gender,@dob,@dop,@nationality,@birthcert,@nationalid,@occupation,@photo,@blood,@eye,@skin,@height,@status,@phone,@posaddress,@physicaladdress,@fullname,@relationship,@phoneno,@postal,@physical,@radio,@type)");
             cmd = new SqlCommand(insertSQL, con); 
               // cmd.ExecuteNonQuery(); comment this line 
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = surname;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@dob", SqlDbType.VarChar).Value = dob;
                cmd.Parameters.Add("@dop", SqlDbType.VarChar).Value = dop;
                cmd.Parameters.Add("@nationality", SqlDbType.VarChar).Value = nationality;
                cmd.Parameters.Add("@birthcert", SqlDbType.VarChar).Value = birthcert;
                cmd.Parameters.Add("@nationalid", SqlDbType.VarChar).Value = nationalid;
                cmd.Parameters.Add("@occupation", SqlDbType.VarChar).Value = occupation;
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = photo;
                cmd.Parameters.Add("@blood", SqlDbType.VarChar).Value = blood;
                cmd.Parameters.Add("@eye", SqlDbType.VarChar).Value = eye;
                cmd.Parameters.Add("@skin", SqlDbType.VarChar).Value = skin;
                cmd.Parameters.Add("@height", SqlDbType.Int).Value = height;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@phone", SqlDbType.Int).Value = phone;
                cmd.Parameters.Add("@posaddress", SqlDbType.VarChar).Value = posaddress;
                cmd.Parameters.Add("@physicaladdress", SqlDbType.VarChar).Value = physicaladdress;
                cmd.Parameters.Add("@relationship", SqlDbType.VarChar).Value = relationship;
                cmd.Parameters.Add("@phoneno", SqlDbType.Int).Value = phoneno;
                cmd.Parameters.Add("@postal", SqlDbType.VarChar).Value = postal;
                cmd.Parameters.Add("@physical", SqlDbType.VarChar).Value = physical;
                cmd.Parameters.Add("@radio", SqlDbType.VarChar).Value = radio;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('1 Row added Successfully');</script");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Select Product Image File');</script");
            }
        }
