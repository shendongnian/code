    public static bool BalancedAB(string str)
    {
        int endPos = str.Length - 1;
        for (int pos = 0; pos <= endPos; pos++)
        {
            if (str[pos] == 'A')
            {
                bool retValue = false;
                while (pos < endPos)
                {
                    if (str[pos + 1] != 'B') { pos++; }
                    else
                    {
                        retValue = true;
                        break;
                    }
                }
                if (!retValue) return false;
            }
        }
        return true;
    }
