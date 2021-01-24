    private void btnSave_Click(object sender, EventArgs e) {
      string title = cboTitle.SelectedItem.ToString();
      string fname = txtFname.Text;
      string lname = txtLname.Text;
      string dob = dtpDOB.Text;
      int stuId = int.Parse(txtSID.Text);
      string status = cboStatus.SelectedItem.ToString();
      string phone = txtPhone.Text;
      string email = txtEmail.Text;
      Student newStudent = new Student();
      newStudent.Title = title;
      newStudent.FirstName = fname;
      newStudent.Lastname = lname;
      newStudent.DOB = dob;
      newStudent.StudentID = stuId;
      newStudent.Status = status;
      newStudent.Phone = phone;
      newStudent.Email = email;
      parentBS.Add(newStudent);
      MessageBox.Show("Data Added", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
      //txtEmail.Clear();
      //txtFname.Clear();
      //txtLname.Clear();
      //txtPhone.Clear();
      //txtSID.Clear();
      this.Close();
    }
