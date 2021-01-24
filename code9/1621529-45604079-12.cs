    //THIS IS IN FORM2 :)
    private void btnNewOk_Click(object sender, EventArgs e)
    {
        string student = textBoxName.Text;
        string[] scores = textBoxNewScores.Text.Split(' '); 
        
        for(int i = 0; i < scores.Length; i++)
        {
            student = student + "|" + scores[i];
        }
        studentInfo.Add(student);
        this.Close();
    }
