            List<string> st1 = new List<string>() { "st11", "st12" };
            List<string> st2 = new List<string>() { "st21", "st22" };
            List<List<string>> stringArrayList = new List<List<string>>();
            stringArrayList.Add(st1);
            stringArrayList.Add(st2);
            string[] n1 = new string[10];
            int i = 0;
            int maxCount = stringArrayList.Max(x => x.Count);
            for (int index = 0; index < maxCount; index++)
            {
                foreach (var list in stringArrayList)
                {
                    if (list.Count > index)
                    {
                        n1[i] = list[index];
                        i++;
                    }
                }
            }
