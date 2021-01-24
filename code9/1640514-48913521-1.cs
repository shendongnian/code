       string Abcd = Console.ReadLine();
            string wspace = "";
                        int len = Abcd.Length;
            for (int i = 0; i <= len-1; i++)
            {
                if (Abcd[i] != ' ')
                {
                    wspace = wspace + Abcd[i];
                }
            }
            Console.WriteLine("The Sring Without Space Is= '"+wspace+"'");
            Console.ReadLine();
