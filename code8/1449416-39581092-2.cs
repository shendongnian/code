    public bool ValidEmail(String email)
    {
        var ok = Reserved(email);
        if (ok)
        {
            ok = System.Text.RegularExpressions.Regex.IsMatch(email, PATTERN);
            if (!ok)
            {
                MessageBox.Show("Failed Email Format");
            }
        } else
        {
            MessageBox.Show("Reserved Word");
        }
        return ok;
    }
