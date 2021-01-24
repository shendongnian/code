    var isExiting = false; 
    foreach (Control cnt in  panel1.Controls)
            {
                if (cnt is TextBox)
                {
                    if(cnt.Text==string.Empty)
                    {
                        MessageBox.Show("All fields are mandatory");
    
                    }
                }
                else if(cnt is ComboBox)
                {
                    ComboBox cmb = (ComboBox)cnt;
                    if(cmb.SelectedIndex == -1)                
                    {
                        isExiting = true;
                        MessageBox.Show("All fields are mandatory");
                        Application.Exit();
    
                    }                      
                }
            }
    
        if(!isExiting){
            string  gender;
            string dob = cmbDate.Text + "/" +cmbMonth.Text + "/"+cmbYear.Text;
            if (rbMale.Checked == true)
                gender = rbMale.Text;
            else
                gender = rbFemale.Text;
    
            query = "Insert into Admissions(Admission_date,Student_name,Father_name,Mother_name,DOB,Gender,Address,State, City,Pincode,Admission_for,Previous_school,Fees)values('" + txtAdmDate.Text + "','" + txtStudentName.Text + "','" + txtFatherName.Text + "','" + txtMotherName.Text + "','" + dob + "','" + gender + "','" + txtAddress.Text + "','" + txtState.Text + "','" + txtCity.Text + "','" + txtPincode.Text + "','" + cmbClass.Text + "','" + txtPreviousSchool.Text + "','" + txtFees.Text + "'); SELECT SCOPE_IDENTITY();";
    
            cmd = new SqlCommand(query,con);
            con.Open();
            int admId = (int)cmd.ExecuteScalar();
            con.Close();
        }//if !isExiting
