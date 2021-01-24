            string num = "1011100";
            char[] myChar = num.ToCharArray();
           
            bool blFirst = false;  //This will check if there is "1" on first element of the input
            bool blLast = false;  //This will check if there is "1" on last element of the input
            if (myChar[0] == '0') //If the condition is true we will remove this on the result
                blFirst = true;
            if (myChar[myChar.Length - 1] == '0')
                blLast = true;
            
            string[] intArr = num.Split('1').ToArray();
            List<string> intResult = new List<string>();
 
            //We will make sure that all results only contains '0' and not empty.
            intResult = intArr.Where(x => x.All(y => y == '0') && x != string.Empty).Select(x => x).ToList();
            if (blFirst == true)
                intResult.RemoveAt(0);
            if (blLast == true)
                intResult.RemoveAt(intResult.Count - 1);
            //After all conditions are met (Get only '0' numbers between 1), that's the time we get the maximum count
            intOutput = intResult.Select(x => x).Max(x => x.Length);
