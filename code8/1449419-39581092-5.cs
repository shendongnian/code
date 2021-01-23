    public void ValidateEmail(String email)
    {
        if (!Reserved(email))
        {
            var ok = System.Text.RegularExpressions.Regex.IsMatch(email, PATTERN);
            if (!ok)
            {
                MessageBox.Show("Failed Email Format");
            }
        } else
        {
            MessageBox.Show("Reserved Word");
        }
    }
