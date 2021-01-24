    static void Main(string[] args)
        {
            int baris = 2, kolom = 2, a=0, b=0;
            Console.Write("Matriks A\n");
            Console.WriteLine("------------");
            Console.WriteLine();
            int[,] matrik_a = new int[3, 3];
            int[,] matrik_b = new int[3, 3];
            for (a = 0; a <= baris; a++)
            {
                for (b = 0; b <= kolom; b++)
                {
                    Console.Write(" Matriks A [" + (a + 0) + "][" + (b + 0) + "] = ");
                    matrik_a[a, b] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine("Matriks B ");
            Console.WriteLine("----------------------------------");
            int sumOfRow = 0;
            for (a = 0; a <= baris; a++)
            {
                for (b = 0; b <= kolom; b++)
                {
                    sumOfRow += matrik_a[a, b];
                }
                Console.WriteLine("sum of row " + a.ToString() + "is: " + sumOfRow.ToString());
                for (b = 0; b <= kolom; b++)
                {
                    matrik_b[a, b] = matrik_a[a, b] + sumOfRow;
                }
                sumOfRow = 0;
            }
            for (a = 0; a <= baris; a++)
            {
                for (b = 0; b <= kolom; b++)
                {
                    Console.Write(matrik_b[a, b]);
                }
                
            }
            Console.ReadLine();
        }
