            double val;
            for (int i = 0; i < allItems.Count; i++)
            {
                for (int j = i; j < allItems.Count; j++)
                {
                    if (i!=j)
                        val = ComputeSimilarity(allItems[i], allItems[j]);
                }
            }
