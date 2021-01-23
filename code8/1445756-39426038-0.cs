            string str = "Tamil";
            List<char> list = str.ToList ();
            list = list.OrderBy(x => x.ToString()).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
