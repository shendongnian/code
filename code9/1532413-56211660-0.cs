            string num = "1011100";
            //trim the 0's at the start and the end, the result num =10111
            num=num.Trim(new Char[] { '0' });
            
            
            string[] intArr = num.Split('1');
   
            List<string> Result = new List<string>();
            foreach(string x in intArr)
            {
                if (x != "")
                {
                    Result.Add(x);
                }
            }
            int Output = Result.Select(x => x).Max(x => x.Length);
