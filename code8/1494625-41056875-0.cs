    static bool FindInString(int p)
    {
        char cha = 'd';
        char chb = 'x';
        if (p < str.Length - 1)
        {
            if (str[p] != cha)
            {
                if (FindInString(p + 1))
                {
                    str[p] = chb;
                    return true;
                }
            }
            else
            {
                str[p] = chb;
                return true;
            }
        }
        return false;
    }
