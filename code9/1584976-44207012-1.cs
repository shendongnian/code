    private static string caesar(string input, int n)
    {
        //  Emrah Süngü's answer makes this part nicer, though it won't 
        //  make any difference at runtime. 
        input = input.Replace("Ä", "Ae");
        input = input.Replace("Ü", "Ue");
        input = input.Replace("Ö", "Oo");
        input = input.Replace("ß", "ss");
        input = input.Replace("ä", "ae");
        input = input.Replace("ü", "ue");
        input = input.Replace("ö", "oe");
        n = n % 94;
        StringBuilder cipher = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            int code = ((int)input[i]);
            if (code >= 33 && code <= (126 - n))
            {
                code = code + n;
                char crypt = Convert.ToChar(code);
                cipher.Append(crypt);
            }
            else if (code > (126 - n) && code <= 126)
            {
                code = ((code + n) % 94);
                char crypt = Convert.ToChar(code);
                cipher.Append(crypt);
            }
            else
            {
                cipher.Append(input[i]);
            }
        }
        return cipher.ToString();
    }
