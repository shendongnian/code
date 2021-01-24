                string param = "1100,1110,0110,0001";
                var matrix = new int[4,4];
                string[] allStrings = param.Split(',');
    
                for(int i = 0; i< allStrings.Count(); i++)
                {
                    string str = allStrings[i];
                    char[] allChars = str.ToCharArray();
                    for (int j = 0; j < allChars.Count(); j++)
                    {
                        matrix[i, j] = Convert.ToInt32(allChars[j].ToString()); // you can use int.tryparse if not sure that input will always be integer
                    }
                }
