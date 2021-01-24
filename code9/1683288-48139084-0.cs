        static void Main(string[] args)
        {
            List<int> lstVal = new List<int>();
            for (;;)
            {
                string str = Console.ReadLine();
                if (str.Trim().Equals(""))
                {
                    break;
                }
                else
                {
                    int iVal;
                    if (int.TryParse(str, out iVal))
                    {
                        lstVal.Add(iVal);
                    }
                }
            }
            Console.WriteLine("Input value : ");
            foreach (int iVal in lstVal)
            {
                Console.WriteLine("{0}", iVal);
            }
            Console.ReadKey(true);
        }
