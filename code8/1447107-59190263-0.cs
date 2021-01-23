            string new_string= String.Concat(s.OrderBy(c => c)); //for sorting string
            for (int i = 0; i < new_string.Length; i++)
            {
                int count = 0;
                for (int j = i; j < new_string.Length; j++)
                {
                    if (new_string[i] == new_string[j])
                    {
                        count++;
                    }
                    else
                    {
                        if (count == 0)
                        { count = 1; }
                        break;
                    }
                }
                Console.WriteLine("count for "+new_string[i]+"is: "+count);
                new_string=new_string.Remove(0, count);
                i = 0;
            }
            Console.ReadKey();
        }
