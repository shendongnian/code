        private void btnAdd_Click(object sender, EventArgs e)
    {
        List<string> SelectedMem = new List<string>();
        frmSelectMembers SelectMembers = new frmSelectMembers(SelectedMem);
        
        if(SelectMembers.ShowDialog() == DialogResult.OK) // this waits until a DialogResult is found
        {
              //DO WHATEVER YOU NEED IN HERE
              string text = SelectMembers.TextBox1.Text;
        }
        SelectMembers.Dispose();
    }
