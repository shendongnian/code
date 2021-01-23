        static void Main(string[] args)
        {
            using (DispClass d = new DispClass())
            {
                var lst = d.Get2();
                //d.Get1();
                foreach (var a in lst)
                {
                    break;
                }
            }
            Console.ReadKey();
        }
