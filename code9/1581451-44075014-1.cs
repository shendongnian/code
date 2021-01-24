    delegate double maxMin(IEnumerable<double> arr);
    public static void GetData()
    {
                double[][] tableData = new double[][]{
                                        new double[] {3500, 70, 10, 80, 3000, 36},
                                        new double[] {4500, 90, 10, 60, 2500, 48 },
                                        new double[] {4000, 80, 9, 90, 2000, 48 },
                                        new double[] {4000, 70, 8, 50, 1500, 60 }
                                      };
    
                int length = tableData.Length;
                double[] requiredValues = new double[length];
    
                maxMin maxMinObj;
                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                        maxMinObj = x => x.Max();
                    else
                        maxMinObj = x => x.Min();
    
                    requiredValues[i] = maxMinObj(tableData[i]);
    
                    Console.WriteLine(requiredValues[i]);
                }
    }
