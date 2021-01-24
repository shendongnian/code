    string s = "AX_1234X_12345_X_CXY";
    string ns = HappyChap(s);
    public string HappyChap(string value)
    {
            int start = value.IndexOf("X_");
            int next = start;
            next = value.IndexOf("X_", start + 1);
            if (next > 0)
            {
                value = value.Remove(next, 1);
            }
            return value;
    }
