            string text1 = @"Lorem ""ipsum dolor"" quisque at ""massa non erat"".Donec auctor ""blandit"" nibh!";
            text1 = text1.Replace("."," ");
            string[] splitted = text1.Split(' ');
            List<int> result = new List<int>();
            bool alreadystarted = false;
            foreach (string element in splitted)
            {
                if (element.Contains("\""))
                {
                    if (alreadystarted == false)
                    {
                        if (element.Count(f => f == '"') != 2)
                        {
                            alreadystarted = true;
                        }
                        result.Add(10);
                    }
                    else
                    {
                        alreadystarted = false;
                        result.Add(10);
                    }
                }
                else
                {
                    if (alreadystarted == true)
                    {
                        result.Add(10);
                    }
                    else
                    {
                        result.Add(0);
                    }
                }
            }
