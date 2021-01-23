                List<string> list = new List<string>();
                list.Add("one");
                list.Add("two");
                Actions action = new Actions();
                action.Style=new string[list.Count];
    
                foreach (var item in list)
                {
                    for (int i = 0; i < action.Style.Length; i++)
                    {
                        action.Style[i] = item.ToString();
                        Console.WriteLine(action.Style[i]);
                    }                  
                }
