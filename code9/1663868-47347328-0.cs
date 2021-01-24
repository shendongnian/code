    public static void FactorialJohn(int[] arr)
                {          
                    
                    List<int> Resarr = new List<int>();
                    arr.ToList().ForEach(x => Resarr.Add(Enumerable.Range(1, x).Aggregate((a, b) => a * b)));
    
                    foreach (var item in Resarr)
                    {
                        Console.WriteLine(item);
                    }
                }
