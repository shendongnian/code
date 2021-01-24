     List<int> list = new List<int>(){1, 2, 3};
            List<int> lstResult = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        //Check if it exist before adding   
                        if (!lstResult.Contains(int.Parse(list[i].ToString() + list[i].ToString() + list[z].ToString())))
                        {
                            lstResult.Add(int.Parse(list[i].ToString() + list[i].ToString() + list[z].ToString()));
                        }
                    }
                     //Check if it exist before adding
                    if (!lstResult.Contains(int.Parse(list[i].ToString() + list[j].ToString() + list[i].ToString())))
                    {
                        lstResult.Add(int.Parse(list[i].ToString() + list[j].ToString() + list[i].ToString()));
                    }
                }
            }
