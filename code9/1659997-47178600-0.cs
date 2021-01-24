    public void FillEmailAddressField(string emailAddress)
        {
            var email = _driver.FindElement(PaymentDetailsResponsiveElements.EmailAddressField);
            var emailText = emailAddress;
    
            foreach (char c in emailText)
            {
                email.SendKeys(c.ToString());
            }
        }
