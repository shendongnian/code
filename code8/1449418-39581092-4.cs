    private bool Reserved(String email)
    {
        var result = false;
        if (!String.IsNullOrEmpty(email))
        {
            var lc = email.ToLower();
            result = _reserved.Any(x => -1 < x.IndexOf(lc));
        }
        return result;
    }
