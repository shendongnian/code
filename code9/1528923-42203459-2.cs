        Form2 form2 = new Form2();
        (form2.Controls.Find("btnOK", true)[0] as Button).Click += btnOK_Click;
        form2.Show();
        private void btnOK_Click(object sender, EventArgs e)
        {
            CopyTheFiles();
        }
