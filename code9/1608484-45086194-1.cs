            int suma = 0;
            int n = 2;
            for (int i = 0; i < n; i++)
            {
                double number;
                if (!double.TryParse(Console.ReadLine(), out number))
                {
                    // Tell user input is invalid
                }
                else
                {
                    suma += (int) number;
                }
            }
            Console.WriteLine("Total " + suma);
