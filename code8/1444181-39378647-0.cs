    private void SubstractList(ref List<string> l1, List<string> l2)
            {
                foreach (string s2 in l2)
                {
                    for (int i = 0; i < l1.Count; i++)
                    {
                        if (l1[i] == s2)
                        {
                            l1.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
