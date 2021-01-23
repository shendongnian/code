        //call this in !ispostback in page_load
        protected void BuildEmailAsLink()
            {
            //Email is different because we have to make the link clickable.
            //navigateurl="mailto:user@example.com?subject=MessageTitle&body=MessageContent"
    
            var email = lnkEmail1.Text;
    
            //Only need to load the email address once on pageload. otherwise reuse it from the UI.
            if (!string.IsNullOrEmpty(email) && (email.Length > 1) && email.Contains("@"))
            {
                //continue;
            }
            else
            {
                email = lnkEmail1.Text.Trim();
            }
    
            if (string.IsNullOrEmpty(email) == false)
            {
                lnkEmail1.NavigateUrl = lnkEmail1.NavigateUrl.Replace("user@example.com", email);
                lnkEmail1.NavigateUrl = lnkEmail1.NavigateUrl.Replace("MessageTitle", "Reaching Out");
                lnkEmail1.NavigateUrl = lnkEmail1.NavigateUrl.Replace("MessageContent",
                    string.IsNullOrEmpty(lblFirstName.Text.Trim()) == false
                        ? string.Format("Hi {0},", lblFirstName.Text.Trim())
                        : "Hi,");
    
                lnkEmail1.Text = email;
                lnkEmail1.Visible = true;
            }
        }
