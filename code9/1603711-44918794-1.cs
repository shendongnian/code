         // This Mehod Definately work for u
    
     string[] arr = new string[3] { "Taha", "Usama", "Alias" };
        
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        for (int j = i + 1; j < arr.Length; j++)
                        {
                            int lth = arr[i].Length < arr[j].Length ? arr[i].Length : arr[j].Length;
                            for (int k = 0; k < lth; k++)
                            {
                                if (arr[i][k] > arr[j][k])
                                {
                                    string temp = arr[i];
                                    arr[i] = arr[j];
                                    arr[j] = temp;
                                    break;
                                }
                                else if (arr[i][k] < arr[j][k])
                                {
                                    break;
                                }
                            }
                        }
                    }
    
    // Display Result by Following Code
    
                    foreach (string s in arr)
                    {
                        Console.WriteLine(s);
                    }
