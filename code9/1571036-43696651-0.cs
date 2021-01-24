            int[] CustomerByMonth = { 60, 50, 40, 30, 20, 10 };
            int[] index = { 0, 1, 2, 3, 4, 5 };
            int tmp = 0;
            for (int i = 0; i < index.Length; ++i)
            {
                for (int j = 0; j < index.Length - 1; ++j)
                {
                    if (CustomerByMonth[index[j]] > CustomerByMonth[index[j + 1]])
                    {
                        tmp = index[j + 1];
                        index[j + 1] = index[j];
                        index[j] = tmp;
                    }
                }
            }
            // Display month number and customer amount for month with highest amount of customers
            Console.Write(index[CustomerByMonth.Length - 1] + " : " + CustomerByMonth[index[CustomerByMonth.Length - 1]]);
