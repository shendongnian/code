     private void Form1_Load(object sender, EventArgs e)
      {
       BindData();
      }
      Public Void BindData()
       {
          if(studentListHome != null)
           {
              mainUniversity.StudentList.Concat(studentListHome).ToList();
              studentListBox.DataSource = mainUniversity.StudentList;
              studentListBox.DisplayMember = "name";
            }
        }
       private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Form2 studentForm = new Form2(this);
          studentForm.ShowDialog();
        }
