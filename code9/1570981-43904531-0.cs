        private DialogResult setFormsToBackground(Form fParent)
        {
            Form dummyForm = new Form();
            dummyForm.ShowInTaskbar = false;
            dummyForm.FormBorderStyle = FormBorderStyle.None;
            dummyForm.Load += ((object sender, EventArgs e) => { (sender as Form).Size = new Size(0, 0); });
            
            List<Form> lstFormsToEnable = new List<Form>();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                try
                {
                    Form checkfrm = Application.OpenForms[i];
                    if (checkfrm != this && dummyForm != this && checkfrm.Enabled)
                    {
                        lstFormsToEnable.Add(checkfrm);
                        checkfrm.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                }
            }
            dummyForm.Show();
            DialogResult result = DialogResult.None;
            if (fParent == null) result = base.ShowDialog();
            else result = base.ShowDialog(fParent);
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                try
                {
                    Form checkfrm = Application.OpenForms[i];
                    checkfrm.Enabled = true;
                }
                catch (Exception ex)
                {
                }
            }
            dummyForm.Close();
            return result;
        }
