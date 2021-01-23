    string original = "(Bob, George, Will, Terry)";
                string result = "";
                string[] splited = original.Split(',');
                for (int i = 0; i < splited.Count(); i++)
                {
                    if(i == splited.Count() - 2)
                    {
                        result += splited[i] + " and";
                    }
                    else if(i == splited.Count() - 1)
                    {
                        result += splited[i];
                    }
                    else
                    {
                        result += splited[i] + ",";
                    }
                }
