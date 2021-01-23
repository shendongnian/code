                // easy and simple try this
                string path = @"Customer\Calls\A1\A2\A3\A4";
                string[] pathArr =  path.Split('\\');
                List<string> list = new List<string>();
                for (int i = 0; i < pathArr.Length; i++)
                {
                    string temp = pathArr[i];
                    if (i > 0)
                    {
                        temp = list[i - 1].ToString() + @"\" + temp;
                    }
                    list.Add(temp);
    
                }
