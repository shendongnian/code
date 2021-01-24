    class StringA
    {
        public StringA(char x, int y, out string res)
        {
            res = "";
            string ConvertedChar = Convert.ToString(x);
            for (int i = 0; i < y; i++)
            {
                res += ConvertedChar;
            }
            // or even shorter
            // res = new string(x, y);
          }
    }
