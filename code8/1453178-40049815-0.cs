    void StringReplace(string initialString)
            {
                bool insideSpecialCharacter = false;
                string[] Pattern = { "A-C", "C-W", "F-H", "B-G" };
                string specialCharacter = "|";
                char[] characters = initialString.ToCharArray();
                
                char?[] Newcharacters = new char?[characters.Length];
                for (int i = 0; i < characters.Length; i++)
                {
                    if (!characters[i].ToString().Equals(specialCharacter))
                    {
                        if (insideSpecialCharacter)
                        {
                            Newcharacters[i] = characters[i];
                        }
                        else
                        {
                            CheckPattern(Pattern, characters, Newcharacters, i);
                        }
                    }
                    else
                    {
                        insideSpecialCharacter = (insideSpecialCharacter) ? false : true;
                    }
                }
                txtSecond.Text = string.Concat(Newcharacters).Trim();
            }
    		
    		//-------Checks the Pattern Array and Replaces the Characters-----------
    		
    private static void CheckPattern(string[] Pattern, char[] characters, char?[] Newcharacters, int i)
            {
                for (int j = 0; j < Pattern.Length; j++)
                {
                    string[] replaceValue = Pattern[j].Split('-');
                    if (characters[i].ToString() == replaceValue[0])
                    {
                        Newcharacters[i] = Convert.ToChar(characters[i].ToString().Replace(characters[i].ToString(), replaceValue[1]));
                        break;
                    }
                    else
                    {
                        Newcharacters[i] = characters[i];
                    }
                }
            }
    
    		
