    public static string RandomString(int characters)
        {
            string s = "";
            for (int i = 0; i < characters; i++)
            {
                int ascii = 0;
                for (int bit = 0; bit < 5; bit++)
                {
                    if (r.Next(2) == 0)
                        continue;
                    ascii += 1 << bit;
                    if (ascii + (1 << (bit + 1)) > 25)
                        break;
                }
                s += Convert.ToChar(97 + ascii);
            }
            return s;
        }
