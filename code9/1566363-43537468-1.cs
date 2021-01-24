        private void ShowHideEmailContents(string email, string email2, string format, string tooltip, bool isReadOnly)
        {
            if (isReadOnly)
            {
                var optionsSetter = new EmailOptionsSetter(tooltip, format, isReadOnly);
                optionsSetter.SetOptions(hlEmail, email);
                optionsSetter.SetOptions(hlEmail2, email2);
                txtEmail.Visible  = !isReadOnly;
                txtEmail2.Visible = !isReadOnly;            
            }
            else
            {
                txtEmail.Text  = email;
                txtEmail2.Text = email2;
            }
        }
