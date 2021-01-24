                try
                {
                    int[] ergebnis = new int[20];
                    var filterString = new List<string>();
                    for (int i = 1; i < result.Length; i++)
                    {
                        int j = Int32.Parse(result[i][12]);
                        ergebnis[i] = j;
                        filterString.Add(string.Format("{0} = '{1}'", "ID", j));
                    }
                    Suche.Filter = string.Join(" OR ", filterString);
                    kitba();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Debug.WriteLine(ex);
                }
