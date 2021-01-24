            string param = "1100,10110,0110,0001";   //"1100,1110,0110,0001";
            
            string[] allStrings = param.Split(',');
            var m = allStrings.Count();
            System.Collections.Generic.List<char[]> listOfCharArr = new System.Collections.Generic.List<char[]>();
            System.Collections.Generic.List<int> lengthList = new System.Collections.Generic.List<int>();
            for(int i = 0; i<m ; i++)
            {
                string str = allStrings[i];
                char[] allChars = str.ToCharArray();
                listOfCharArr.Add(allChars);
                lengthList.Add(allChars.Count());                
            }
            int maxLength = lengthList.Max();
            int[,] matrix = new int[m, maxLength] ;
            for(int i = 0; i<m ; i++)
            {
                for (int j = 0; j < maxLength; j++)
                {
                    char[] temp = listOfCharArr[i];
                    if (j < listOfCharArr[i].Count())
                        matrix[i, j] = Convert.ToInt32(listOfCharArr[i][j].ToString()); // you can use int.tryparse if not sure that input will always be integer
                    else
                        matrix[i, j] = -1; // I have used -1 as no value, you can use whatever you require
                }
            }
