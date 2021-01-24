    private void txt_SurName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                // You need to assign the changed text back to the control!
                txt_SurName.Text = Utillity.ToTitle(txt_SurName.Text);
                txt_SurName.Focus();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }
