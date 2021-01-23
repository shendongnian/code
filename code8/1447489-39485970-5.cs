            //convert dictionary of dictionaries to 2D array
            int groupNum = dictionaries.Keys.Count, dateNum = dictionaries.First().Value.Keys.Count;
            string[,] array = new string[groupNum + 1, dateNum + 1];
            array[0, 0] = "group";
            //assign dates
            for (int i = 1; i <= dateNum; i++)
                array[0, i] = dictionaries.First().Value.Keys.ElementAt(i - 1);
            //assign groups
            for (int i = 1; i <= groupNum; i++)
                array[i, 0] = dictionaries.Keys.ElementAt(i - 1);
            //assign counts
            for (int group = 1; group <= groupNum; group++)
                for (int date = 1; date <= dateNum; date++)
                    array[group, date] = dictionaries[array[group, 0]][array[0, date]].ToString();
            //print the 2D array
            for (int row = 0; row < groupNum + 1; row++)
            {
                for (int column = 0; column < dateNum + 1; column++)
                    Console.Write("{0} ", array[row, column]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
