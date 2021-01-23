            public static string GenerateSequence(int col)
        {
            if (col>=1 && col <= 36)
            {  
                string schars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return schars[col-1].ToString();
            }
            int div = col / 36;
            int mod = col % 36;
            if (mod == 0) { mod = 36; div--; }
            return GenerateSequence(div) + GenerateSequence(mod);
        }
        static void Main(string[] args)
        {
            for (int i = 1; i < 250; i++)
            {
                Console.WriteLine(i + "---" + GenerateSequence(i));
            }
        }
