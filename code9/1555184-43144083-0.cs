    while ((item = stream_reader.ReadLine()) != null)
            {
                myArr = item.Split(',');  
                if (a == 1)
                {
                    for (int i = 1; i < myArr.Length; i++)
                    {
                        if (i != 5)
                        {
                            string var;
                            string zahl;
                            var = myArr[i];
                            zahl = stringToDoubleToString(var);
                            myArr[i] = zahl;
                        }
                    }
                }
                a = 1;
                dataset.Tables["FinData"].Rows.Add(myArr);
