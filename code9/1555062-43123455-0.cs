            string a = "saffsa1ad12314";
            string finalString = string.Empty;
            char[] chars = a.ToCharArray();
            for (int i = chars.Length -1; i >= 0; i--)
            {
                if (char.IsDigit(chars[i]))
                {
                    finalString += chars[i];
                }
                else
                {
                    break; //so you dont get a number after a letter
                    //could put your mbox here
                }
            }
            //Now you just have to reverse the string
            char[] revMe = finalString.ToCharArray();
            Array.Reverse(revMe);
            finalString = string.Empty;
            foreach (char x in revMe)
            {
                finalString += x;
            }
            Console.WriteLine(finalString);
            //outputs: 12314
