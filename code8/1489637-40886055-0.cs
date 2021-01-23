    List<string> list = new List<string>() { "A", "B", "C", "B", "C", "B", "D"};
        for (int i = 0; i < list.Count; i++)
            {
                string x = list.ElementAt(i);
                int count = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list.ElementAt(j).Equals(x))
                    {
                        count++;
                        if (count>1)
                        {
                            list.RemoveAll(y => y.Equals(x));
                            count = 0;
                        }
                    }
                }
            }
