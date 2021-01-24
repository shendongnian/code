    // This will reverse the string and special characters will just stay there.
        public string ReverseString(string rString)
        {
            StringBuilder ss = new StringBuilder(rString);
            int y = 0;
            for(int i=rString.Length-1;i>=0;i--)
            {
                if(Char.IsLetter(Convert.ToChar(rString.Substring(i,1))))
                {                   
                    for (int k = y; k < rString.Length; k++)
                    {
                        if (Char.IsLetter(Convert.ToChar(rString.Substring(k, 1))))
                        {
                            char st1 = Convert.ToChar(rString.Substring(k, 1));
                            char st2 = Convert.ToChar(rString.Substring(i, 1));
                            ss[rString.IndexOf(rString.Substring(i, 1))] = st1;
                            ss[rString.IndexOf(rString.Substring(k, 1))] = st2;
                            y++;
                            break;
                        }
                        else
                        {
                            y++;
                        }
                    }                    
                }
            }
            
            return ss.ToString();
        }
