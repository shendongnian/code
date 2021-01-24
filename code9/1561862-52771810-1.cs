        // This will reverse the string and special characters will just stay there.
        public string ReverseString(string rString)
        {
            StringBuilder ss = new StringBuilder(rString);
            int y = 0;
            // The idea is to swap values. Like swapping first value with last one. It will keep swapping unless it reaches at the middle of the string where no swapping will be needed.
            // This first loop is to detect first values.
            for(int i=rString.Length-1;i>=0;i--)
            {
                // This condition is to check if the values is String or not. If it is not string then it is considered as special character which will just stay there at same old position.
                if(Char.IsLetter(Convert.ToChar(rString.Substring(i,1))))
                {          
                    // This is second loop which is starting from end to swap values from end with first.         
                    for (int k = y; k < rString.Length; k++)
                    {
                        // Again checking last values if values are string or not. 
                        if (Char.IsLetter(Convert.ToChar(rString.Substring(k, 1))))
                        {
                            // This is swapping. So st1 is First value in that string
                            // st2 is the last item in that string
                            char st1 = Convert.ToChar(rString.Substring(k, 1));
                            char st2 = Convert.ToChar(rString.Substring(i, 1));
                            //This is swapping. So last item will go to first position and first item will go to last position, To make sure string is reversed.
                            // Remember when the string value is Special Character, swapping will move forward without swapping.
                            ss[rString.IndexOf(rString.Substring(i, 1))] = st1;
                            ss[rString.IndexOf(rString.Substring(k, 1))] = st2;
                            y++;
                            // When the swapping is done for first 2 items. The loop will stop to change the values.
                            break;
                        }
                        else
                        {
                            // This is just increment if value was Special character. 
                            y++;
                        }
                    }                    
                }
            }
            
            return ss.ToString();
        }
