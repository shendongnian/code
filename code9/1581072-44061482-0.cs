            int arrayIndex = 0;
            int month = 1;
            for (int i = 0; i < 12; i++)
            {
                if (myArray[arrayIndex].Split(',')[0] == Convert.ToString(month))
                {
                    MyData.Add(myArray[arrayIndex]);
                    month++;
                    arrayIndex++;
                }
                else
                {
                    MyData.Add(Convert.ToString(month) + ",0");
                    month++;
                }
            }
