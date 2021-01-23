        translateButton.Click += translateButton_Click;
        private void translateButton_Click(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (String.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.Text = "Call";
                callButton.Enabled = false;
            }
            else
            {
                callButton.Text = "Call " + translatedNumber;
                callButton.Enabled = true;
            }
        }
