        static void Main(string[] args)
        {
            string asd = "PT. Mitra Adiperkasa Tbk                                    01.710.880.4-054.000                                        Wisma 46 Kota BNI Lt. 8                                     Jl Jend Sudirman Kav 1, Jak Pus     ";
            foreach (string s in asd.Trim().Split(new string[] { "  ", "    " }, StringSplitOptions.RemoveEmptyEntries))
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
