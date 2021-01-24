    private void delete_Click(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            Control control = btn.Parent;
    
            if (questions.Controls.Contains(control))
            {
                questions.Controls.Remove(control);
                control.Dispose();
                TotalNumberAdded--;
                questions.Controls.Clear();
                for (int i = 0; i < TotalNumberAdded; ++i)
                {
                    AddQuestion(i + 1);
                }
                Response.Write("Number of Questions:" + TotalNumberAdded);
            }
        }
