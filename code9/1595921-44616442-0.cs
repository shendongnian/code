    private Form formWin = null;
    private void makeForm(String option)
    {
        if(formWin == null)
        {
            formWin = new Form();
            formWin.TopMost = true;
            formWin.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            formWin.Size = new Size(500, 600);
            formWin.StartPosition = FormStartPosition.Manual;
            formWin.Location = new Point(1366 - formWin.Size.Width, 768 - formWin.Size.Width);
            formWin.BackColor = Color.White;
            formWin.TransparencyKey = Color.White;
    
            var formWinModel = new PictureBox
            {
                Name = "formWin",
                Size = new Size(formWin.Size.Width, formWin.Size.Height),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Trans.Properties.Resources.Form_Special,
                Location = new Point(0, 0),
            };
    
            formWin.Controls.Add(formWinModel);
        }            
    
        if (option == "show")
        {
            formWin.Show();
        }
    
        if (option == "exit")
        {
            formWin.Visible = false;
            formWin.Close();
            formWin.Dispose();
            formWin = null;
        }
    }
