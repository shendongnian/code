    public int Compare(string x, string y)
    {
        if (x == null || y == null) return 0;
        var nameX = x.Substring(x.LastIndexOf('/'));
        var nameY = y.Substring(y.LastIndexOf('/'));
        var nameXParts = nameX.Split('.');
        var nameYParts = nameY.Split('.');
        int a, b;
        var rs = int.TryParse(nameXParts[0], out a);
        var rs2 = int.TryParse(nameYParts[0], out b);
        var nameXDigits = string.Empty;
        if (!rs)
        {
            for (int i = 0; i < nameXParts[0].Length; i++)
            {
                if (Char.IsDigit(nameXParts[0][i]))
                    nameXDigits += nameXParts[0][i];
            }
        }
        var nameYDigits = string.Empty;
        if (!rs2)
        {
            for (int i = 0; i < nameYParts[0].Length; i++)
            {
                if (Char.IsDigit(nameYParts[0][i]))
                    nameYDigits += nameYParts[0][i];
            }
        }
        int.TryParse(nameXDigits, out a);
        int.TryParse(nameYDigits, out b);
        if (a == b || a == 0 && b == 0) return 0;
        return a > b ? 1 : -1;
    }
