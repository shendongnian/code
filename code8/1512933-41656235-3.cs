        private void button1_Click(object sender, EventArgs e)
        {
            using (var subForm = Program.FormFactory.CreateForm("frmSubForm").Value)
            {
                subForm.ShowDialog(this);
            }
        }
