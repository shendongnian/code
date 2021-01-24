    private void btnOK_Click(object sender, EventArgs e)
    {
        string student = txtName.Text;
        if (lbScores.Items != null && lbScores.Items.Count > 0)
        {
            foreach (var item in lbScores.Items)
            {
                student = student + "|" + item.ToString();
            }
        }
        updateStudentInfo.Add(student);
        form3.listForm1.Items.RemoveAt(form3.listForm1.SelectedIndex);
        this.Close();
    }
