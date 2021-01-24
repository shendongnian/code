    List<char> list1 = "gbd".ToList<char>();
                List<char> list2 = "student".ToList<char>();
                string result = string.Empty;
                for (int i = 0; i <  list2.Count(); i++)
                {
                    try
                    {
                        result = result + list1[i] + list2[i];
                    }
                catch
                {
                    result = result + list2[i];
                }
            }
