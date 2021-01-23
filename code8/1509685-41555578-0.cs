     private void myFunc()
        {
            List<int> Result = new List<int>();
            for (int i = 0; i <= 30; i++)
            {
                    if (IsMyResult(i.ToString()) == true)
                        Result.Add(i);  
            }
        }
        private bool IsMyResult(string x)
        {
            string[] numbersToSearch = { "2", "5" }; // you can add here all the numbers you want to be inside the number you are searching
    
            foreach (char digit in x)
            {
                if (numbersToSearch.Contains(digit.ToString()))
                {
                    // do nothing it containes desired digit
                }
                else
                {
                    // return false its not the result
                    return false;
                }
            }
            // if code reach here it must be true
            return true;
        }
