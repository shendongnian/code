    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
            {
                int num1, num2;
                int[] buffer = new int[list.Count];
                list.CopyTo(buffer, 0);
                List<int> list2 = buffer.ToList();
                list2.Sort();
                int max = list2.Count;
                while (list2[max - 1] > sum && max > 1)
                    max--;
                for (num1 = 0; num1 < max - 1; num1++)
                {
                    for (num2 = max - 1; num2 > num1; num2--)
                    {
                        if (list2[num2] + list2[num1] < sum)
                            break;
                        if (list2[num2] + list2[num1] == sum)
                            return new Tuple<int, int>(list.IndexOf(list2[num1]), list.IndexOf(list2[num2]));
                    }
                }
                return null;
            }
