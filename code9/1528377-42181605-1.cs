            List<string> st1 = new List<string> { "st11", "st12" };
            List<string> st2 = new List<string> { "st21", "st22" };
            List<List<string>> stringArrayList = new List<List<string>> {st1, st2};
            int maxCount = stringArrayList.Max(x => x.Count);
            int totalItems = 0;
            stringArrayList.ForEach(x=> totalItems+= x.Count);
            string[] n1 = new string[totalItems];
            int i = 0;
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
