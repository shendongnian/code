    public static void find()
            {
                List<string> list1 = new List<string>() { "Mango", "Banana", "Orange", "Apple", "BlackBerry" };
                List<string> list2 = new List<string>() { "Apple", "Cherry", "Kiwifruit", "Banana", "Papaya" };
    
    
                for (int i = 0; i < list1.Count; i++)
                {
                    for (int x = 0; x < list2.Count; x++)
                    {
                        if (list2[x].Contains(list1[i]))
                        {
                            Console.WriteLine("Find :" + list2[x]);
    
                            //break for of list2
                            break;
                        } 
                    }
                }
    
            }
