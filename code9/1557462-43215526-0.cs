    public static string Decode(string input)
    {
        int[] error = { 2, 9, 5, 4, 1, 6, 7, 12, 19, 3, 1, 0, 21, 17 };
        StringBuilder buffer = new StringBuilder(input);
        int count = 0;
        for (int x = input.Length - 1; x >= 0; x--) {
            buffer[x] = (char)(input[x] - 48 + error[count]);
            count++;
            if (count >= 14)
                count = 0;
        }
        return buffer.ToString();
    }
