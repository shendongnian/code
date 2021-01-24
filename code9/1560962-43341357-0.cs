        static void PrintLottoNumbers(int[,] lottoN)
        {
            for (int x = 0; x < lottoN.GetLength(0); x++)
            {
                Console.WriteLine("Game" + GetRowText(lottoN, x) );
            }
        }//Print Function For Lotto Numbers
        static string GetRowText(int[,] lottoN, int row)
        {
            var builder = new StringBuilder();
            for (int x = 0; x < lottoN.GetLength(1); x++)
            {
                builder.Append(" " + lottoN[row, x]);
            }
            return builder.ToString();
        }
